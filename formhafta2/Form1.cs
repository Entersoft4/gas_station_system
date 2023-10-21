using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace formhafta2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //lbox1 > draw mode > owner darw fixed olması gerekiyor.
            /*lbox1.DrawMode = DrawMode.OwnerDrawFixed;
            lbox1.DrawItem += lbox1_DrawItem;*/
        }
        double kasa = 50000;
        static double limit=10000;
        double d_benzin = limit, d_dizel = limit, d_lpg = limit;
        int al_benzin = 30, al_dizel = 35, al_lpg = 15;
        double tutar, miktar;

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lbox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void lbox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            /*if(cbox1.SelectedIndex == 0)
            {
                e.DrawBackground();
                Graphics g = e.Graphics;

                // draw the background color you want
                // mine is set to olive, change it to whatever you want
                g.FillRectangle(new SolidBrush(Color.Red), e.Bounds);

                // draw the text of the list item, not doing this will only show
                // the background color
                // you will need to get the text of item to display
                g.DrawString((sender as ListBox).Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));

                e.DrawFocusRectangle();
            }
            if(cbox1.SelectedIndex == 1)
            {
                e.DrawBackground();
                Graphics g = e.Graphics;

                // draw the background color you want
                // mine is set to olive, change it to whatever you want
                g.FillRectangle(new SolidBrush(Color.Green), e.Bounds);

                // draw the text of the list item, not doing this will only show
                // the background color
                // you will need to get the text of item to display
                g.DrawString((sender as ListBox).Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));

                e.DrawFocusRectangle();
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Depo doluluk oranı gösterme:
            pbar1.Value = Convert.ToInt32((100 * d_benzin) / limit);
            pbar2.Value = Convert.ToInt32((100 * d_dizel) / limit);
            pbar3.Value = Convert.ToInt32((100 * d_lpg) / limit);
            l4.Text = "%" + pbar1.Value;
            l5.Text = "%" + pbar2.Value;
            l6.Text = "%" + pbar3.Value;
            //Kasadaki parayı gösterme:
            l9.Text = "=" + kasa;
        }

        private void b2_Click(object sender, EventArgs e)
        {
            b1.Enabled = false;
        }

        private void b1_Click(object sender, EventArgs e)
        {
            b2.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void b3_Click(object sender, EventArgs e)
        {
            if(rb1.Checked==true)//Benzin seçeneği
            {
                if(cbox1.Text == "ALIŞ")//Alış seçeneği
                {
                    if(b2.Enabled==false)//LİTRE seçeneği
                    {
                        if (tbox1.TextLength!=0)//textbox alanı
                        {
                            miktar = Convert.ToDouble(tbox1.Text);
                            tutar = miktar * al_benzin;
                            MessageBox.Show("Ödeyeceğiniz tutar:" + tutar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (kasa >= tutar)
                            {
                                if (d_benzin+miktar <= limit)
                                {
                                    kasa -= tutar;
                                    lbox1.Items.Add(" - " + tutar);
                                    d_benzin += miktar;
                                }
                                else
                                {
                                    MessageBox.Show("Depoda yeterli alan yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kasada yeterli para yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen alacağınız miktarı giriniz.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                    else if(b1.Enabled==false)//TL seçeneği
                    {
                        if (tbox1.TextLength != 0)//textbox alanı
                        {
                            tutar = Convert.ToDouble(tbox1.Text);
                            miktar = tutar / al_benzin;
                            MessageBox.Show("Alacağınız miktar:" + miktar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (kasa >= tutar)
                            {
                                if (d_benzin + miktar <= limit)
                                {
                                    kasa -= tutar;
                                    lbox1.Items.Add(" - " + tutar);
                                    d_benzin += miktar;
                                }
                                else
                                {
                                    MessageBox.Show("Depoda yeterli alan yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kasada yeterli para yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen ödeyeceğiniz tutarı giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen LİTRE veya TL seçiniz.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else if (cbox1.Text == "SATIŞ")//Satış seçeneği
                {
                    if (b2.Enabled == false)//LİTRE seçeneği
                    {
                        if (tbox1.TextLength != 0)//textbox alanı
                        {
                            miktar = Convert.ToDouble(tbox1.Text);
                            tutar = miktar * (al_benzin*1.2);
                            MessageBox.Show("Ödeyeceğiniz tutar:" + tutar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (d_benzin - miktar > 0)
                            {
                                kasa += tutar;
                                lbox1.Items.Add(" + " + tutar);
                                d_benzin -= miktar;
                            }
                            else
                            {
                                MessageBox.Show("Depoda yeterli yakıt yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen satacağınız miktarı giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (b1.Enabled == false)//TL seçeneği
                    {
                        if (tbox1.TextLength != 0)//textbox alanı
                        {
                            tutar = Convert.ToDouble(tbox1.Text);
                            miktar = tutar / (al_benzin*1.2);
                            MessageBox.Show("Alacağınız miktar:" + miktar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (d_benzin - miktar > 0)
                            {
                                kasa += tutar;
                                lbox1.Items.Add(" + " + tutar);
                                d_benzin -= miktar;
                            }
                            else
                            {
                                MessageBox.Show("Depoda yeterli yakıt yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen ödenecek tutarı giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen LİTRE veya TL seçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen yapılacak işlemi seçiniz.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else if(rb2.Checked==true)//Dizel seçeneği
            {
                if (cbox1.Text == "ALIŞ")//Alış seçeneği
                {
                    if (b2.Enabled == false)//LİTRE seçeneği
                    {
                        if (tbox1.TextLength != 0)//textbox alanı
                        {
                            miktar = Convert.ToDouble(tbox1.Text);
                            tutar = miktar * al_dizel;
                            MessageBox.Show("Ödeyeceğiniz tutar:" + tutar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (kasa >= tutar)
                            {
                                if (d_dizel + miktar <= limit)
                                {
                                    kasa -= tutar;
                                    lbox1.Items.Add(" - " + tutar);
                                    d_dizel += miktar;
                                }
                                else
                                {
                                    MessageBox.Show("Depoda yeterli alan yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kasada yeterli para yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen alacağınız miktarı giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (b1.Enabled == false)//TL seçeneği
                    {
                        if (tbox1.TextLength != 0)//textbox alanı
                        {
                            tutar = Convert.ToDouble(tbox1.Text);
                            miktar = tutar / al_dizel;
                            MessageBox.Show("Alacağınız miktar:" + miktar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (kasa >= tutar)
                            {
                                if (d_dizel + miktar <= limit)
                                {
                                    kasa -= tutar;
                                    lbox1.Items.Add(" - " + tutar);
                                    d_dizel += miktar;
                                }
                                else
                                {
                                    MessageBox.Show("Depoda yeterli alan yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kasada yeterli para yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen ödeyeceğiniz tutarı giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen LİTRE veya TL seçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cbox1.Text == "SATIŞ")//Satış seçeneği
                {
                    if (b2.Enabled == false)//LİTRE seçeneği
                    {
                        if (tbox1.TextLength != 0)//textbox alanı
                        {
                            miktar = Convert.ToDouble(tbox1.Text);
                            tutar = miktar * (al_dizel * 1.2);
                            MessageBox.Show("Ödeyeceğiniz tutar:" + tutar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (d_dizel - miktar > 0)
                            {
                                kasa += tutar;
                                lbox1.Items.Add(" + " + tutar);
                                d_dizel -= miktar;
                            }
                            else
                            {
                                MessageBox.Show("Depoda yeterli yakıt yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen satacağınız miktarı giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (b1.Enabled == false)//TL seçeneği
                    {
                        if (tbox1.TextLength != 0)//textbox alanı
                        {
                            tutar = Convert.ToDouble(tbox1.Text);
                            miktar = tutar / (al_dizel * 1.2);
                            MessageBox.Show("Alacağınız miktar:" + miktar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (d_dizel - miktar > 0)
                            {
                                kasa += tutar;
                                lbox1.Items.Add(" + " + tutar);
                                d_dizel -= miktar;
                            }
                            else
                            {
                                MessageBox.Show("Depoda yeterli yakıt yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen ödenecek tutarı giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen LİTRE veya TL seçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen yapılacak işlemi seçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(rb3.Checked==true)//Lpg seçeneği
            {
                if (cbox1.Text == "ALIŞ")//Alış seçeneği
                {
                    if (b2.Enabled == false)//LİTRE seçeneği
                    {
                        if (tbox1.TextLength != 0)//textbox alanı
                        {
                            miktar = Convert.ToDouble(tbox1.Text);
                            tutar = miktar * al_lpg;
                            MessageBox.Show("Ödeyeceğiniz tutar:" + tutar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (kasa >= tutar)
                            {
                                if (d_lpg + miktar <= limit)
                                {
                                    kasa -= tutar;
                                    lbox1.Items.Add(" - " + tutar);
                                    d_lpg += miktar;
                                }
                                else
                                {
                                    MessageBox.Show("Depoda yeterli alan yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kasada yeterli para yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen alacağınız miktarı giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (b1.Enabled == false)//TL seçeneği
                    {
                        if (tbox1.TextLength != 0)//textbox alanı
                        {
                            tutar = Convert.ToDouble(tbox1.Text);
                            miktar = tutar / al_lpg;
                            MessageBox.Show("Alacağınız miktar:" + miktar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (kasa >= tutar)
                            {
                                if (d_lpg + miktar <= limit)
                                {
                                    kasa -= tutar;
                                    lbox1.Items.Add(" - " + tutar);
                                    d_lpg += miktar;
                                }
                                else
                                {
                                    MessageBox.Show("Depoda yeterli alan yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kasada yeterli para yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen ödeyeceğiniz tutarı giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen LİTRE veya TL seçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cbox1.Text == "SATIŞ")//Satış seçeneği
                {
                    if (b2.Enabled == false)//LİTRE seçeneği
                    {
                        if (tbox1.TextLength != 0)//textbox alanı
                        {
                            miktar = Convert.ToDouble(tbox1.Text);
                            tutar = miktar * (al_lpg * 1.2);
                            MessageBox.Show("Ödeyeceğiniz tutar:" + tutar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (d_lpg - miktar > 0)
                            {
                                kasa += tutar;
                                lbox1.Items.Add(" + " + tutar);
                                d_lpg -= miktar;
                            }
                            else
                            {
                                MessageBox.Show("Depoda yeterli yakıt yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen satacağınız miktarı giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (b1.Enabled == false)//TL seçeneği
                    {
                        if (tbox1.TextLength != 0)//textbox alanı
                        {
                            tutar = Convert.ToDouble(tbox1.Text);
                            miktar = tutar / (al_lpg * 1.2);
                            MessageBox.Show("Alacağınız miktar:" + miktar, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (d_lpg - miktar > 0)
                            {
                                kasa += tutar;
                                lbox1.Items.Add(" + " + tutar);
                                d_lpg -= miktar;
                            }
                            else
                            {
                                MessageBox.Show("Depoda yeterli yakıt yok.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen ödenecek tutarı giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen LİTRE veya TL seçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen yapılacak işlemi seçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen yakıt türünü seçiniz.", "HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            //Sıfırlama işlemleri:
            rb1.Checked = false;
            rb2.Checked = false;
            rb3.Checked = false;
            b1.Enabled = true;
            b2.Enabled = true;
            //combobox dropdownstyle dropdownlist resettext?
            cbox1.ResetText();
            tbox1.Clear();
            //Depo doluluk oranı gösterme:
            pbar1.Value = Convert.ToInt32((100 * d_benzin) / limit);
            pbar2.Value = Convert.ToInt32((100 * d_dizel) / limit);
            pbar3.Value = Convert.ToInt32((100 * d_lpg) / limit);
            l4.Text = "%" + pbar1.Value;
            l5.Text = "%" + pbar2.Value;
            l6.Text = "%" + pbar3.Value;
            //Kasadaki parayı gösterme:
            l9.Text = "=" + kasa;
        }
    }
}