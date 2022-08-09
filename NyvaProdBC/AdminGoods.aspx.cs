﻿using NyvaProdBC.Entity.Contexts;
using NyvaProdBC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NyvaProdBC
{
    public partial class AdminGoods : System.Web.UI.Page
    {
        public class SelectorTrinity
        {
            public Button GoToView { get; set; }
            public Button GoToEdit { get; set; }
            public Button GoToDelete { get; set; }
            public SelectorTrinity() { }
            public SelectorTrinity(Button view, Button edit, Button delete)
            {
                GoToView = view;
                GoToEdit = edit;
                GoToDelete = delete;
            }
        }
        List<SelectorTrinity> selectors = new List<SelectorTrinity>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //gdGoods.DataSource = new Entity.Contexts.GoodContext().Goods.ToList();
            //gdGoods.DataBind();
            RefreshTableUI();
        }
        void RefreshTableUI()
        {
            var db = new Entity.Contexts.GoodContext();
            var goods = db.Goods.ToList();
            for (int i = 0; i < goods.Count; i++)
            {
                System.Threading.Thread.Sleep(1);
                Image img = new Image();
                img.ImageUrl = goods[i].ImageUrl;
                img.Height = 100;
                img.Width = 100;

                TableCell tcId = new TableCell();
                Label lblItemId = new Label();
                lblItemId.Text = "#" + goods[i].Id.ToString();
                tcId.CssClass = "tableCell";
                tcId.Controls.Add(lblItemId);

                TableCell tcName = new TableCell();
                Label lblItemName = new Label();
                lblItemName.Text = goods[i].Name.ToString();
                tcName.CssClass = "tableCell";
                tcName.Controls.Add(lblItemName);

                TableCell tcOrderPrice = new TableCell();
                Label lblOrderPrice = new Label();
                lblOrderPrice.Text = goods[i].OrderPrice.ToString();
                tcOrderPrice.CssClass = "tableCell";
                tcOrderPrice.Controls.Add(lblOrderPrice);

                TableCell tcSellPrice = new TableCell();
                Label lblSellPrice = new Label();
                lblSellPrice.Text = goods[i].SellPrice.ToString();
                tcSellPrice.CssClass = "tableCell";//TROUBLE
                tcSellPrice.Controls.Add(lblSellPrice);

                TableCell tcWeightKg = new TableCell();
                Label lblWeightKg = new Label();
                lblWeightKg.Text = goods[i].WeightKg.ToString();
                tcWeightKg.CssClass = "tableCell";
                tcWeightKg.Controls.Add(lblWeightKg);

                TableCell tcImage = new TableCell();
                Image image = new Image();
                image.Height = 100;
                image.Width = 100;
                image.ImageUrl = goods[i].ImageUrl.ToString();
                tcImage.CssClass = "tableCell";
                tcImage.Controls.Add(image);

                TableCell tcRegionCode = new TableCell();
                Label lblRegionCode = new Label();
                lblRegionCode.Text = goods[i].Barcode.RegionCode.ToString();
                tcRegionCode.CssClass = "tableCell";
                tcRegionCode.Controls.Add(lblRegionCode);

                TableCell tcProducerCode = new TableCell();
                Label lblProducerCode = new Label();
                lblProducerCode.Text = goods[i].Barcode.ProducerCode.ToString();
                tcProducerCode.CssClass = "tableCell";
                tcProducerCode.Controls.Add(lblProducerCode);

                TableCell tcGoodCode = new TableCell();
                Label lblGoodCode = new Label();
                lblGoodCode.Text = goods[i].Barcode.GoodCode.ToString();
                tcGoodCode.CssClass = "tableCell";
                tcGoodCode.Controls.Add(lblGoodCode);

                TableCell tcControlDigit = new TableCell();
                Label lblControlDigit = new Label();
                lblControlDigit.Text = goods[i].Barcode.ControlDigit.ToString();
                tcControlDigit.CssClass = "tableCell";
                tcControlDigit.Controls.Add(lblControlDigit);


                TableCell tcView = new TableCell();
                tcView.CssClass = "tableCell";
                Button btnView = new Button();
                btnView.BackColor = GlobalValues.idleColor;
                btnView.Click += GoToView;
                btnView.Text = "✓";
                tcView.Controls.Add(btnView);

                TableCell tcEdit = new TableCell();
                tcEdit.CssClass = "tableCell";
                Button btnEdit = new Button();
                btnEdit.BackColor = GlobalValues.idleColor;
                btnEdit.Click += GoToEdit;
                btnEdit.Text = "✎";
                tcEdit.Controls.Add(btnEdit);

                TableCell tcDelete = new TableCell();
                tcDelete.CssClass = "tableCell";
                Button btnDelete = new Button();
                btnDelete.BackColor = GlobalValues.idleColor;
                btnDelete.Click += GoToDelete;
                btnDelete.Text = "χ";
                tcDelete.Controls.Add(btnDelete);

                SelectorTrinity selectorTrinity = new SelectorTrinity();
                selectorTrinity.GoToView = btnView;
                selectorTrinity.GoToEdit = btnEdit;
                selectorTrinity.GoToDelete = btnDelete;
                selectors.Add(selectorTrinity);

                TableRow tr = new TableRow();
                tr.Cells.Add(tcId);
                tr.Cells.Add(tcName);
                tr.Cells.Add(tcOrderPrice);
                tr.Cells.Add(tcSellPrice);
                tr.Cells.Add(tcWeightKg);
                tr.Cells.Add(tcImage);
                tr.Cells.Add(tcRegionCode);
                tr.Cells.Add(tcProducerCode);
                tr.Cells.Add(tcGoodCode);
                tr.Cells.Add(tcControlDigit);
                tr.Cells.Add(tcView);
                tr.Cells.Add(tcEdit);
                tr.Cells.Add(tcDelete);
                tblGoods.Rows.Add(tr);
            }
        }
        int ViewButtonIndex(Button vb)
        {
            for (int i = 0; i < selectors.Count; i++)
                if (selectors[i].GoToView == vb)
                    return i;
            return -1;
        }
        int DeleteButtonIndex(Button db)
        {
            for (int i = 0; i < selectors.Count; i++)
                if (selectors[i].GoToDelete == db)
                    return i;
            return -1;
        }
        int EditButtonIndex(Button eb)
        {
            for (int i = 0; i < selectors.Count; i++)
                if (selectors[i].GoToEdit == eb)
                    return i;
            return -1;
        }
        private void GoToView(object sender, EventArgs e)
        {
            int index = ViewButtonIndex((Button)sender);
            var db = new GoodContext();
            var goods = db.Goods.ToList();
            Response.Redirect("/ViewGood?id=" + goods[index].Id);
        }
        private void GoToEdit(object sender, EventArgs e)
        {
            int index = EditButtonIndex((Button)sender);
            var db = new GoodContext();
            var goods = db.Goods.ToList();
            Response.Redirect("/GoodEdition?id=" + goods[index].Id);
        }
        private void GoToDelete(object sender, EventArgs e)
        {
            int index = DeleteButtonIndex((Button)sender);
            var db = new GoodContext();
            var goods = db.Goods.ToList();
            Response.Redirect("/GoodDeletion?id=" + goods[index].Id);
        }
    }
}