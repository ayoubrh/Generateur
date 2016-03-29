using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int aid = 100 - int.Parse(prcH.Text);
            prcF.Text = aid.ToString();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {

           // BoxTVEntities db = new BoxTVEntities();
            Random rnd = new Random();
            var db = new BoxTVEntities();
            int nbr_c = int.Parse(nbrclient.Text);
            int pr_f = int.Parse(prcF.Text);
            int pr_h = int.Parse(prcH.Text);
            //using (var context = new BoxTVEntities())
            //{
            //var Categorie = context.Categorie.Find(15);
            //context.Blogs.Add(blog);
            //context.Categorie.Remove(Categorie);
            //context.SaveChanges();
            //}

            // Display the ProgressBar control.
            progressBar.Visible = true;
            // Set Minimum to 1 to represent the first file being copied.
            progressBar.Minimum = 1;
            // Set Maximum to the total number of files to copy.
            progressBar.Maximum = nbr_c * 100 + 1;
            // Set the initial value of the ProgressBar.
            progressBar.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            progressBar.Step = 1;
            int h = (int)((Double)nbr_c * ((Double)pr_h / (Double)100));
            int f = (int)((Double)nbr_c * ((Double)pr_f / (Double)100));
            MessageBox.Show("H : " + h + " F : " + f);
            int[] cat = new int[14];
            cat[0] = int.Parse(cat1.Text);
            cat[1] = int.Parse(cat2.Text);
            cat[2] = int.Parse(cat3.Text);
            cat[3] = int.Parse(cat4.Text);
            cat[4] = int.Parse(cat5.Text);
            cat[5] = int.Parse(cat11.Text);
            cat[6] = int.Parse(cat13.Text);
            cat[7] = int.Parse(cat6.Text);
            cat[8] = int.Parse(cat7.Text);
            cat[9] = int.Parse(cat8.Text);
            cat[10] = int.Parse(cat9.Text);
            cat[11] = int.Parse(cat10.Text);
            cat[12] = int.Parse(cat12.Text);
            cat[13] = int.Parse(cat14.Text);
            int som = 0;
            for (int i = 0; i < 14; i++)
            {
                som = som + cat[i];
            }
            if (som == 100)
            {
                IList<Customer> newC = new List<Customer>();
                IList<Date> dates = new List<Date>();

                for (int i=0;i< h; i++)
                {
                    Customer c = new Customer();
                    c.age = rnd.Next(18, 70);
                    c.numchildren = rnd.Next(6);
                    c.numtv = rnd.Next(1, 4);
                    //int aid_gender = rnd.Next(2);
                    int aid_stat = rnd.Next(5);
                    //string gender = "";
                    //string stat = "";
                    c.gender = "Homme";
                    
                    if (aid_stat == 0)
                    {
                        c.situation = "Célibataire";
                    }
                    else if (aid_stat == 1)
                    {
                        c.situation = "Mariée";
                    }
                    else if (aid_stat == 2)
                    {
                        c.situation = "Divorcé";
                    }
                    else if (aid_stat == 3)
                    {
                        c.situation = "Veuf";
                    }
                    else
                    {
                        c.situation = "Pacsé";
                    }

                    //db.Entry(c).State = System.Data.Entity.EntityState.Added;
                    //int x = await(db.SaveChangesAsync());
                    //db.Customer(c);
                    //db.SaveChanges();
                    //db.Customer.Add(c);
                    //db.SaveChanges();
                    //newC.Add(c);
                    db.Customer.Add(c);
                    db.SaveChanges();
                    for (int j = 0; j < 14; j++)
                    {
                        var Categorie = db.Categorie.Find(j+1);
                        for(int k = 1; k <= cat[j]; k++)
                        {
                            Date d = new Date();
                            //DateTime start = new DateTime(2010, 1, 1,00,00,00);
                            int year = rnd.Next(2010,2016);
                            int month = rnd.Next(1, 13);
                            int day = rnd.Next(1, 29);
                            int hour = rnd.Next(0, 24);
                            int min = rnd.Next(0, 60);
                            int sec = rnd.Next(0, 60);
                            d.datedebut = new DateTime(year, month, day, hour, min, sec);
                            d.duree = rnd.Next(30,181);
                            d.Customer1 = c;
                            d.Categorie = Categorie;
                            //db.Date.Add(d);
                            //db.SaveChanges();
                            dates.Add(d);
                            progressBar.PerformStep();
                            //MessageBox.Show(" Date " + d.datedebut);
                        }

                    }
                    //MessageBox.Show(" client "+ i );

                }
                for (int i = 0; i < f; i++)
                {
                    Customer c = new Customer();
                    c.age = rnd.Next(18, 70);
                    c.numchildren = rnd.Next(6);
                    c.numtv = rnd.Next(1, 4);
                    //int aid_gender = rnd.Next(2);
                    int aid_stat = rnd.Next(5);
                    //string gender = "";
                    //string stat = "";
                    c.gender = "Femme";

                    if (aid_stat == 0)
                    {
                        c.situation = "Célibataire";
                    }
                    else if (aid_stat == 1)
                    {
                        c.situation = "Mariée";
                    }
                    else if (aid_stat == 2)
                    {
                        c.situation = "Divorcé";
                    }
                    else if (aid_stat == 3)
                    {
                        c.situation = "Veuf";
                    }
                    else
                    {
                        c.situation = "Pacsé";
                    }

                    //db.Entry(c).State = System.Data.Entity.EntityState.Added;
                    //db.SaveChanges();
                    //db.Customer(c);
                    //db.SaveChanges();
                    //db.Customer.Add(c);
                    //db.SaveChanges();
                    //newC.Add(c);
                    db.Customer.Add(c);
                    db.SaveChanges();
                    for (int j = 0; j < 14; j++)
                    {
                        var Categorie = db.Categorie.Find(j + 1);
                        for (int k = 1; k <= cat[j]; k++)
                        {
                            Date d = new Date();
                            //DateTime start = new DateTime(2010, 1, 1,00,00,00);
                            int year = rnd.Next(2010, 2016);
                            int month = rnd.Next(1, 13);
                            int day = rnd.Next(1, 29);
                            int hour = rnd.Next(0, 24);
                            int min = rnd.Next(0, 60);
                            int sec = rnd.Next(0, 60);
                            d.datedebut = new DateTime(year, month, day, hour, min, sec);
                            d.duree = rnd.Next(30, 181);
                            d.Customer1 = c;
                            d.Categorie = Categorie;
                            //db.Date.Add(d);
                            //db.SaveChanges();
                            dates.Add(d);
                            progressBar.PerformStep();
                            //MessageBox.Show(" Date " + d.datedebut);
                        }

                    }
                    //MessageBox.Show(" client " + i);

                }

                //MessageBox.Show("age : "+newC[0].age+" sexe : "+ newC[1].gender);
                //int x = db.SaveChanges();

                //using (var context = new BoxTVEntities())
                //{
                //var blog = new Blog { Name = "ADO.NET Blog" };
                //context.Blogs.Add(blog);
                // context.Customer.AddRange(newC);
                //context.SaveChanges();
                //}
                db.Date.AddRange(dates);
                db.SaveChanges();
                MessageBox.Show(" Done ");
            }
            else
            {
                MessageBox.Show("la somme des pourcentages des catégories doit être egale à 100% au lieu de : " + som);
            }

        }

        

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cat4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void cat13_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            button.Controls.Clear();
            progressBar.Value = 1;
        }
    }
}
