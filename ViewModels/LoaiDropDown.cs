using DoAn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.ViewModels
{
    public class LoaiDropDown
    {
        public LoaiDropDown(IEnumerable<Loai> items, string textField, string valueField, string controllName, int? loaiDuocChon=null)
        {
            Items = items;
            DataTextField = textField;
            DataValueField = valueField;
            SelectedValues = loaiDuocChon;
            ControllName = controllName;
        }
        public string ControllName { get; set; }
        public string DataTextField { get; }
        public string DataValueField { get; }
        public IEnumerable<Loai> Items { get; }
        public int? SelectedValues { get; }
    }
}
