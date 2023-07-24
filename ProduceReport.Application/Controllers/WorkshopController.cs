using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using ProduceReport.Contracts;
using ProduceReport.Core;

namespace ProduceReport.Application.Controllers
{
    public class WorkshopController : Controller
    {
        private readonly IEntityService<Workshop> _service;
        private readonly IMapper _mapper;       

        public WorkshopController(IEntityService<Workshop> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var workshops = await _service.GetAll();

            var response = workshops
                .AsQueryable()
                .ProjectTo<WorkshopResponse>(_mapper.ConfigurationProvider);

            return View(response);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WorkshopRequest request)
        {
            if (ModelState.IsValid)
            {
                var workshop = _mapper.Map<Workshop>(request);
                _service.Add(workshop);
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var workshop = await _service.GetById(id);
            if (workshop == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<WorkshopResponse>(workshop);

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WorkshopResponse dto)
        {
            if (ModelState.IsValid)
            {
                var workshop = _mapper.Map<Workshop>(dto);
                _service.Edit(workshop);
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
            var workshop = await _service.GetById(id);
            if (workshop == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<WorkshopResponse>(workshop);

            return View(response);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult>DeletePost(int? id)
        {
            var workshop = await _service.GetById(id);
            if (workshop == null)
            {
                return NotFound();
            }

            await _service.Delete(workshop.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
