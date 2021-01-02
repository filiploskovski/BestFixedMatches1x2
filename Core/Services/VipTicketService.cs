using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Code;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Hosting;
using Shared.DbInit.Repository;

namespace Core.Services
{
    public class VipTicketService : IVipTicketService
    {
        private readonly IHtmlService _htmlService;
        private readonly IRepository<RVipTicket> _vipTicketRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public VipTicketService(IHtmlService htmlService, IRepository<RVipTicket> vipTicketRepository, IHostingEnvironment hostingEnvironment)
        {
            _htmlService = htmlService;
            _vipTicketRepository = vipTicketRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<Tuple<HtmlModel, List<VipTicketModel>>> Index()
        {
            return new Tuple<HtmlModel, List<VipTicketModel>>(await _htmlService.HtmlByCode(Const.VT),
                await _vipTicketRepository.GetAllBy(q => q.OrderByDescending(x => x.Date).Take(4).Map()));
        }

        public async Task<Tuple<HtmlModel, List<VipTicketModel>>> VipTicketArchive()
        {
            return new Tuple<HtmlModel, List<VipTicketModel>>(await _htmlService.HtmlByCode(Const.VTA),
                await _vipTicketRepository.GetAllBy(q => q.OrderByDescending(x => x.Date).Map()));
        }

        public async Task<Tuple<HtmlModel, VipTicketModel>> VipTicketSinge(int id)
        {
            var model = await _vipTicketRepository.GetFirstBy(item => item.Where(q => q.RVipTicketId == id).Map());
            if(model == null) throw new NullReferenceException("Id not found !!! Init tracking id address");
            return new Tuple<HtmlModel, VipTicketModel>(await _htmlService.HtmlByCode(Const.VTA), model);
        }

        public async Task<VipTicketLoadModel> Load(VipTicketLoadModel model)
        {
            if (model.Id == 0)
            {
                return new VipTicketLoadModel()
                {
                    Grid = await _vipTicketRepository.GetAllBy(item => item.OrderByDescending(q => q.Date).Map()),
                    Html = (await _htmlService.HtmlByCode(Const.VT)).Html
                };
            }
            else
            {
                var entity = await _vipTicketRepository.GetById(model.Id);
                return new VipTicketLoadModel()
                {
                    Id = entity.RVipTicketId,
                    Date = entity.Date.ToString("yyyy-MM-dd"),
                    AltTag = entity.Alt,
                    ImgUrl = entity.Img,
                    Grid = await _vipTicketRepository.GetAllBy(item => item.OrderByDescending(q => q.Date).Map()),
                    Html = (await _htmlService.HtmlByCode(Const.VT)).Html
                };
            }
        }

        public async Task Save_Update(VipTicketLoadModel model)
        {
            var basePathExists = System.IO.Directory.Exists(GetPathToTickets());
            if (!basePathExists) Directory.CreateDirectory(GetPathToTickets());
            

            if (model.Id == 0)
            {
                if(model.File == null) throw new NullReferenceException($"File not found !!!");
                
                var fileName = $"{Guid.NewGuid().ToString()}_{DateTime.Now.Date:yyyy-MM-dd}_{model.File.FileName}";
                var path = Path.Combine(GetPathToTickets(), fileName);

                using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    model.File.CopyTo(fileStream);
                    fileStream.Close();
                    fileStream.Dispose();
                }

                await _vipTicketRepository.Create(new RVipTicket()
                {
                    Date = Convert.ToDateTime(model.Date),
                    Img = fileName,
                    Alt = model.AltTag,
                });
            }
            else
            {
                var entity = await _vipTicketRepository.GetById(model.Id);
                
                if (model.File != null)
                {
                    var fileName = $"{Guid.NewGuid().ToString()}_{DateTime.Now.Date:yyyy-MM-dd}_{model.File.FileName}";
                    var path = Path.Combine(GetPathToTickets(), fileName);

                    if (File.Exists(Path.Combine(GetPathToTickets(),entity.Img)))
                       File.Delete(Path.Combine(GetPathToTickets(),entity.Img));

                   using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                   {
                       model.File.CopyTo(fileStream);
                       fileStream.Close();
                       fileStream.Dispose();
                   }
                   entity.Img = fileName;
                }

                entity.Alt = model.AltTag;
                entity.Date = Convert.ToDateTime(model.Date);
                await _vipTicketRepository.Update(entity);
            }
        }

        public async Task Save_Html(VipTicketLoadModel model)
        {
            var html = await _htmlService.HtmlByCode(Const.VT);
            await _htmlService.Update(new HtmlLoadModel()
            {
                Id = html.Id,
                Html = model.Html
            });
        }

        public async Task Delete(int id)
        {
            var entity = await _vipTicketRepository.GetById(id);
            if (entity == null) throw new NullReferenceException($"Match with id {id} cannot be found");
            
            var path = Path.Combine(GetPathToTickets(), entity.Img);
            if (File.Exists(path))
                File.Delete(path);

            await _vipTicketRepository.Delete(entity);
        }

        private string GetPathToTickets()
        {
            return Path.Combine(_hostingEnvironment.WebRootPath, "images", "tickets");
        }
    }
}