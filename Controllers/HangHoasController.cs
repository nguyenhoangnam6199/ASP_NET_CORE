using AutoMapper;
using Buoi17_18_19_EFCore_CRUD_AJAX.Entities;
using Buoi17_18_19_EFCore_CRUD_AJAX.Helpers;
using Buoi17_18_19_EFCore_CRUD_AJAX.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi17_18_19_EFCore_CRUD_AJAX.Controllers
{
    public class HangHoasController : Controller
    {
        private readonly eStore20Context _context;
        private readonly IMapper _mapper;
        public const int ITEMS_PER_PAGE = 5;

        public HangHoasController(eStore20Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult PhanTrang(int page = 1)
        {
            ViewBag.TrangHienTai = page;

            //filter data nếu có
            var dshh = _context.HangHoa.AsQueryable();

            ViewBag.TongSoTrang = Math.Ceiling(1.0 * dshh.Count() / ITEMS_PER_PAGE);

            dshh = dshh.Skip((page - 1) * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);

            var data = _mapper.Map<List<HangHoaTimKiem>>(dshh.Select(hh => new HangHoaTimKiem
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia.Value,
                GiamGia = hh.GiamGia,
                NgaySanXuat = hh.NgaySx,
                Loai = hh.MaLoaiNavigation.TenLoai
            }).ToList());

            return View(data);

        }
        public IActionResult TimKiem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TimKiem(string TuKhoa, double? GiaTu, double? GiaDen)
        {
            var dshh = _context.HangHoa.AsQueryable();
            if (!string.IsNullOrEmpty(TuKhoa))
            {
                dshh = dshh.Where(hh => hh.TenHh.Contains(TuKhoa));
            }
            if (GiaTu.HasValue && GiaDen.HasValue)
            {
                dshh = dshh.Where(hh => hh.DonGia.Value >= GiaTu && hh.DonGia.Value <= GiaDen);
            }

            var data = _mapper.Map<List<HangHoaTimKiem>>(dshh.Select(hh => new HangHoaTimKiem
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia.Value,
                GiamGia = hh.GiamGia,
                NgaySanXuat = hh.NgaySx,
                Loai = hh.MaLoaiNavigation.TenLoai
            }).ToList());
            return View(data);

        }

        // GET: HangHoas
        public async Task<IActionResult> Index()
        {
            //var eStore20Context = _context.HangHoa.Include(h => h.MaLoaiNavigation).Include(h => h.MaNccNavigation);
            //return View(await eStore20Context.ToListAsync());

            //IQueryable - lưu cấu trúc
            var dsHangHoa = _context.HangHoa
                .Select(hh => new HangHoaViewModel
                {
                    MaHh = hh.MaHh,
                    TenHh = hh.TenHh,
                    DonGia = hh.DonGia.Value,
                    Hinh = hh.Hinh,
                    Loai = hh.MaLoaiNavigation.TenLoai,
                    NhaCungCap = hh.MaNccNavigation.TenCongTy
                });

            return View("HangHoaView", await dsHangHoa.ToListAsync());
        }

        // GET: HangHoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoa
                .Include(h => h.MaLoaiNavigation)
                .Include(h => h.MaNccNavigation)
                .FirstOrDefaultAsync(m => m.MaHh == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // GET: HangHoas/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.Loai, "MaLoai", "TenLoai");
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCap, "MaNcc", "TenCongTy");
            return View();
        }

        // POST: HangHoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHh,TenHh,MaLoai,MoTaDonVi,DonGia,NgaySx,GiamGia,SoLanXem,MoTa,MaNcc")] HangHoa hangHoa, IFormFile Hinh)
        {
            if (ModelState.IsValid)
            {
                hangHoa.Hinh = FileHelper.UpLoadFileToFolder(Hinh, "HangHoa");
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.Loai, "MaLoai", "TenLoai", hangHoa.MaLoai);
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCap, "MaNcc", "TenCongTy", hangHoa.MaNcc);
            return View(hangHoa);
        }

        // GET: HangHoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoa.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }
            ViewData["MaLoai"] = new SelectList(_context.Loai, "MaLoai", "TenLoai", hangHoa.MaLoai);
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCap, "MaNcc", "TenCongTy", hangHoa.MaNcc);
            return View(hangHoa);
        }

        // POST: HangHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHh,TenHh,MaLoai,MoTaDonVi,DonGia,Hinh,NgaySx,GiamGia,SoLanXem,MoTa,MaNcc")] HangHoa hangHoa,
            IFormFile myFile)
        {
            if (id != hangHoa.MaHh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (myFile != null)
                    {
                        hangHoa.Hinh = FileHelper.UpLoadFileToFolder(myFile, "HangHoa");
                    }
                    _context.Update(hangHoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangHoaExists(hangHoa.MaHh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.Loai, "MaLoai", "TenLoai", hangHoa.MaLoai);
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCap, "MaNcc", "TenCongTy", hangHoa.MaNcc);
            return View(hangHoa);
        }

        // GET: HangHoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var hangHoa = await _context.HangHoa
            //    .Include(h => h.MaLoaiNavigation)
            //    .Include(h => h.MaNccNavigation)
            //    .FirstOrDefaultAsync(m => m.MaHh == id);
            //if (hangHoa == null)
            //{
            //    return NotFound();
            //}

            //return View(hangHoa);
            var hangHoa = await _context.HangHoa.FindAsync(id);
            _context.HangHoa.Remove(hangHoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: HangHoas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var hangHoa = await _context.HangHoa.FindAsync(id);
        //    _context.HangHoa.Remove(hangHoa);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool HangHoaExists(int id)
        {
            return _context.HangHoa.Any(e => e.MaHh == id);
        }
    }
}
