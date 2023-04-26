using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderApp;

namespace OrderForm {
  public partial class FormDetailEdit : Form {
    public OrderDetail Detail { get; set; }

    public FormDetailEdit() {
      InitializeComponent();
    }

    public FormDetailEdit(OrderDetail detail):this() {
      this.Detail = detail;
      this.bdsDetail.DataSource = detail;
      bdsGoods.Add(new Product("1", "note", 10.0));
      bdsGoods.Add(new Product("2", "hold", 20.0));
      bdsGoods.Add(new Product("3", "slide", 30.0));
      bdsGoods.Add(new Product("4", "break", 100.0));
    }

    private void btnOK_Click(object sender, EventArgs e) {

    }

    private void cbxGoods_SelectedIndexChanged(object sender, EventArgs e)
    {
      throw new System.NotImplementedException();
    }
  }
}
