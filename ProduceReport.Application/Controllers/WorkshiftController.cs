using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProduceReport.Application.Models;
using ProduceReport.Contracts;
using ProduceReport.Core;

namespace ProduceReport.Application.Controllers
{
    public class WorkshiftController : Controller
    {
        private readonly IEntityService<Workshift> _workshiftService;
        private readonly IEntityService<Workshop> _workshopService;
        private readonly IMapper _mapper;

        public WorkshiftController(IEntityService<Workshift> workshiftService
            ,IEntityService<Workshop> workshopService
            ,IMapper mapper)
        {
            _workshiftService = workshiftService;
            _workshopService = workshopService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var workshifts = await _workshiftService.GetAll();

            var response = workshifts
                .AsQueryable()
                .ProjectTo<WorkshiftResponse>(_mapper.ConfigurationProvider);

            var workshiftListVM = new WorkshiftListVM()
            {
                WorkshiftResponses = response,
                IsWorkshopsExists = _workshopService.GetAll().Result.Any()
            };

            return View(workshiftListVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            WorkshiftCreateVM workshiftVM = new WorkshiftCreateVM()
            {
                WorkshiftRequest = new WorkshiftRequest()
                {
                    Date = DateTime.Today
                },
                WorkshopSelectList = _workshopService
                    .GetAll().Result.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };           

            return View(workshiftVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkshiftCreateVM dto)
        {

            if(ModelState.IsValid)
            {
                var request = _mapper.Map<Workshift>(dto.WorkshiftRequest);
                await _workshiftService.Add(request);
                return RedirectToAction(nameof(Index));
            }

            dto.WorkshopSelectList = _workshopService
                .GetAll().Result.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return View(dto);            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var workshift = await _workshiftService.GetById(id);
            if (workshift == null)
            {
                return NotFound();
            }

            WorkshiftEditVM workshiftVM = new WorkshiftEditVM()
            {
                WorkshiftResponse = _mapper.Map<WorkshiftResponse>(workshift),
                WorkshopSelectList = _workshopService
                    .GetAll().Result.Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
            };
            return View(workshiftVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WorkshiftEditVM dto)
        {
            if (ModelState.IsValid)
            {
                var workshift = _mapper.Map<Workshift>(dto.WorkshiftResponse);
                _workshiftService.Edit(workshift);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var workshift = await _workshiftService.GetById(id);
            if (workshift == null)
            {
                return NotFound();
            }

            WorkshiftEditVM workshiftVM = new WorkshiftEditVM()
            {
                WorkshiftResponse = _mapper.Map<WorkshiftResponse>(workshift),
                WorkshopSelectList = _workshopService
                    .GetAll().Result.Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
            };
            return View(workshiftVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> DeletePost(int? id)
        {
            var workshift = await _workshiftService.GetById(id);
            if (workshift == null)
            {
                return NotFound();
            }

            await _workshiftService.Delete(workshift.Id);

            return RedirectToAction(nameof(Index));
        }

    }

}
