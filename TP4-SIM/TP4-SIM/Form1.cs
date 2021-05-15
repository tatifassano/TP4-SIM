using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP4_SIM
{
    public partial class Form1 : Form
    {
        private int cantidadDecimales = 2;
        private int stockIni;
        private int semana;
        private int demanda;
        private int demora;
        private int stock;
        private int llegada;
        private int disponible;
        private double rndDemanda;
        private double rndDemora;
        private int puntoRepo;
        private string orden;
        private int pedidoLote;
        private int llegadaAux;
        private int faltante;
        private Boolean hayPedido;
        private double ko;
        private double km;
        private double ks;
        private double costoTotal;
        private double costoTotalAc;
        private double costoProm;
        private double costoOrden;
        private double costoMant;
        private double costoFaltante;
        private int diaPedido;
        private string res;






        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_StockIni.Text = Convert.ToString(15);
            txt_Pedido.Text = Convert.ToString(15);
            txt_Reposicion.Text = Convert.ToString(10);
            txt_Ko.Text = Convert.ToString(50);
            txt_Km.Text = Convert.ToString(5);
            txt_Ks.Text = Convert.ToString(8);
            txt_Semanas.Text = Convert.ToString(150);
            txt_Desde.Text = Convert.ToString(1);

        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_StockIni.Text = "";
            //txt_Pedido.Text = "";
            txt_Reposicion.Text = "";
            txt_Ko.Text = "";
            txt_Km.Text = "";
            txt_Ks.Text = "";
            txt_Desde.Text = "";
        }

        private int Demanda(double rnd)
        {
            if (rnd < .05)
                return 3;
            if (rnd < 0.18)
                return 4;
            if (rnd < 0.39)
                return 5;
            if (rnd < 0.66)
                return 6;
            else
                return 7;

        }

        private int Demora(double rnd)
        {
            if (rnd < 0.42)
                return 1;
            if (rnd < 0.74)
                return 2;
            else
                return 3;

        }

        private void btn_Simular_Click(object sender, EventArgs e)
        {
            dgTabla1.Rows.Clear();

            //variable general
            double rnd;
            hayPedido = false;
            //asigno variables
            
            stockIni = Convert.ToInt32(txt_StockIni.Text);
            puntoRepo = Convert.ToInt32(txt_Reposicion.Text);
            pedidoLote = Convert.ToInt32(txt_Pedido.Text);
            ko = Convert.ToDouble(txt_Ko.Text);
            km = Convert.ToDouble(txt_Km.Text);
            ks = Convert.ToDouble(txt_Ks.Text);

            IList<Object> filaActual = new Object[16];

            if(Convert.ToInt32(txt_Semanas.Text) == 0 || Convert.ToInt32(txt_Semanas.Text) < 0)
            {
                MessageBox.Show("Ingrese valor para cantidad de semanas");
            }

            Random aleatorio = new Random();

            rnd = aleatorio.NextDouble();

            //empiezo el for
            for (int i = 1; i <= Convert.ToInt32(txt_Semanas.Text); i++)
            {

                //semana
                filaActual[0] = Convert.ToString(i);

                //Genero un rnd y calculo Demanda
                rnd = aleatorio.NextDouble();
                filaActual[1] = Math.Round(rnd, cantidadDecimales);
                demanda = Demanda(rnd);
                filaActual[2] = demanda;

                //if (i == 1)
                //{

                //    filaActual[8] = stockIni - Convert.ToInt32(filaActual[2]);
                    
                //    if (Convert.ToInt32(filaActual[8]) <= puntoRepo)
                //    {
                //        rnd = aleatorio.NextDouble();
                //        filaActual[3] = Math.Round(rnd, cantidadDecimales);
                //        demora = Demora(rnd);
                //        hayPedido = true;
                //        filaActual[4] = demora;
                //        //hayPedido = true;
                //        filaActual[5] = "Si";
                //        filaActual[6] = Convert.ToInt32(filaActual[4]) + Convert.ToInt32(filaActual[0]);
                //        diaPedido = Convert.ToInt32(filaActual[6]);
                //        //hayPedido = true;
                //        if (Convert.ToInt32(filaActual[8]) < 0)
                //        {
                //            filaActual[8] = 0;
                //        }
                //        filaActual[10] = ko;
                //        filaActual[11] = Convert.ToInt32(filaActual[8]) * km;
                //        filaActual[12] = 0;
                //        filaActual[13] = Convert.ToInt32(filaActual[10]) + Convert.ToInt32(filaActual[11]) + Convert.ToInt32(filaActual[12]);
                //        filaActual[14] = Convert.ToInt32(filaActual[13]) + Convert.ToInt32(filaActual[14]);
                //        filaActual[15] = Math.Round(Convert.ToDouble(filaActual[14]) / Convert.ToDouble(filaActual[0]), 2);

                //    }
                //    else
                //    {
                //        filaActual[4] = "";
                //        hayPedido = false;
                //        filaActual[5] = "No";
                //        filaActual[6] = 0;
                //        //diaPedido = Convert.ToInt32(filaActual[6]);
                //        //hayPedido = false;
                //        filaActual[10] = 0;
                //        filaActual[11] = Convert.ToInt32(filaActual[8]) * km;
                //        filaActual[12] = 0;
                //        filaActual[13] = Convert.ToInt32(filaActual[10]) + Convert.ToInt32(filaActual[11]) + Convert.ToInt32(filaActual[12]);
                //        filaActual[14] = Convert.ToInt32(filaActual[13]) + Convert.ToInt32(filaActual[14]);
                //        filaActual[15] = Math.Round(Convert.ToDouble(filaActual[14]) / Convert.ToDouble(filaActual[0]), 2);
                //    }

                //}
                

                if (i >= 1)
                {
                    filaActual[8] = stockIni - Convert.ToInt32(filaActual[2]);

                    if (diaPedido == Convert.ToInt32(filaActual[0]))
                    {
                        
                            filaActual[7] = pedidoLote;
                            filaActual[8] = Convert.ToInt32(filaActual[8]) + Convert.ToInt32(filaActual[7]) - Convert.ToInt32(filaActual[2]);


                            if (Convert.ToInt32(filaActual[8]) <= puntoRepo)
                            {
                                rnd = aleatorio.NextDouble();
                                filaActual[3] = Math.Round(rnd, cantidadDecimales);
                                demora = Demora(rnd);
                                hayPedido = true;
                                filaActual[4] = demora;
                                //hayPedido = true;
                                filaActual[5] = "Si";
                                filaActual[6] = Convert.ToInt32(filaActual[4]) + Convert.ToInt32(filaActual[0]);
                                diaPedido = Convert.ToInt32(filaActual[6]);
                                filaActual[8] = Convert.ToInt32(filaActual[8]);
                                filaActual[10] = ko;
                                filaActual[11] = Convert.ToInt32(filaActual[8]) * km;
                                filaActual[12] = 0;
                                filaActual[13] = Convert.ToInt32(filaActual[10]) + Convert.ToInt32(filaActual[11]) + Convert.ToInt32(filaActual[12]);
                                filaActual[14] = Convert.ToInt32(filaActual[13]) + Convert.ToInt32(filaActual[14]);
                                filaActual[15] = Math.Round(Convert.ToDouble(filaActual[14]) / Convert.ToDouble(filaActual[0]), 2);
                                filaActual[9] = "";

                            }
                        

                        if(Convert.ToInt32(filaActual[8]) > puntoRepo)
                        {
                            filaActual[3] = "";
                            hayPedido = false;
                            filaActual[4] = "";
                            //hayPedido = false;
                            filaActual[5] = "No";
                            filaActual[6] = "";
                            //hayPedido = false;
                            //filaActual[7] = 0;
                            filaActual[8] = Convert.ToInt32(filaActual[8]);
                            filaActual[10] = 0;
                            filaActual[11] = Convert.ToInt32(filaActual[8]) * km;
                            filaActual[12] = 0;
                            filaActual[13] = Convert.ToInt32(filaActual[10]) + Convert.ToInt32(filaActual[11]) + Convert.ToInt32(filaActual[12]);
                            filaActual[14] = Convert.ToInt32(filaActual[13]) + Convert.ToInt32(filaActual[14]);
                            filaActual[15] = Math.Round(Convert.ToDouble(filaActual[14]) / Convert.ToDouble(filaActual[0]), 2);
                            filaActual[9] = "";

                        }

                        
                    }

                    if(diaPedido != Convert.ToInt32(filaActual[0]) && hayPedido == true)
                    {
                        filaActual[3] = "";
                        filaActual[4] = "";
                        filaActual[5] = "No";
                        filaActual[6] = "";
                        filaActual[7] = 0;
                        faltante = Convert.ToInt32(filaActual[8]) - Convert.ToInt32(filaActual[2]);
                        filaActual[7] = 0;
                        filaActual[8] = Convert.ToInt32(filaActual[8]) + Convert.ToInt32(filaActual[7]) - Convert.ToInt32(filaActual[2]);
                        if (faltante < 0)
                        {
                            filaActual[9] = faltante * -1;
                        }
                        else
                        {
                            filaActual[9] = 0;
                        }
                        //filaActual[8] = Convert.ToInt32(filaActual[8]) + Convert.ToInt32(filaActual[7]) - Convert.ToInt32(filaActual[2]);
                        if (Convert.ToInt32(filaActual[8]) < 0)
                        {
                            filaActual[8] = 0;
                        }

                        filaActual[10] = 0;
                        filaActual[11] = Convert.ToInt32(filaActual[8]) * km;
                        filaActual[12] = Convert.ToInt32(filaActual[9]) * ks;
                        filaActual[13] = Convert.ToInt32(filaActual[10]) + Convert.ToInt32(filaActual[11]) + Convert.ToInt32(filaActual[12]);
                        filaActual[14] = Convert.ToInt32(filaActual[13]) + Convert.ToInt32(filaActual[14]);
                        filaActual[15] = Math.Round(Convert.ToDouble(filaActual[14]) / Convert.ToDouble(filaActual[0]), 2);

                    }



                    if(diaPedido != Convert.ToInt32(filaActual[0]) && hayPedido == false)
                    {
                        faltante = Convert.ToInt32(filaActual[8]) - Convert.ToInt32(filaActual[2]);
                        filaActual[7] = 0;
                        filaActual[8] = Convert.ToInt32(filaActual[8]) + Convert.ToInt32(filaActual[7]) - Convert.ToInt32(filaActual[2]);
                        //faltante = Convert.ToInt32(filaActual[8]) - Convert.ToInt32(filaActual[2]);

                        if (Convert.ToInt16(filaActual[8]) <= puntoRepo)
                        {
                            rnd = aleatorio.NextDouble();
                            filaActual[3] = Math.Round(rnd, cantidadDecimales);
                            demora = Demora(rnd);
                            filaActual[4] = demora;
                            hayPedido = true;
                            filaActual[5] = "Si";
                            filaActual[6] = Convert.ToInt32(filaActual[4]) + Convert.ToInt32(filaActual[0]);
                            //faltante = Convert.ToInt32(filaActual[8]) - Convert.ToInt32(filaActual[2]);
                            filaActual[8] = Convert.ToInt32(filaActual[8]);
                            diaPedido = Convert.ToInt32(filaActual[6]);
                            //faltante = Convert.ToInt32(filaActual[8]) - Convert.ToInt32(filaActual[2]);
                            if (faltante < 0)
                            {
                                filaActual[9] = faltante * -1;
                            }
                            else
                            {
                                filaActual[9] = 0;
                            }
                            //filaActual[8] = Convert.ToInt32(filaActual[8]) + Convert.ToInt32(filaActual[7]) - Convert.ToInt32(filaActual[2]);
                            if (Convert.ToInt32(filaActual[8]) < 0)
                            {
                                filaActual[8] = 0;
                            }

                            filaActual[10] = ko;
                            filaActual[11] = Convert.ToInt32(filaActual[8]) * km;
                            filaActual[12] = Convert.ToInt32(filaActual[9]) * ks;
                            filaActual[13] = Convert.ToInt32(filaActual[10]) + Convert.ToInt32(filaActual[11]) + Convert.ToInt32(filaActual[12]);
                            filaActual[14] = Convert.ToInt32(filaActual[13]) + Convert.ToInt32(filaActual[14]);
                            filaActual[15] = Math.Round(Convert.ToDouble(filaActual[14]) / Convert.ToDouble(filaActual[0]), 2);
                        }
                        if (Convert.ToInt16(filaActual[8]) > puntoRepo)
                        {
                            filaActual[3] = "";
                            filaActual[4] = "";
                            filaActual[5] = "No";
                            filaActual[6] = "";
                            //faltante = Convert.ToInt32(filaActual[8]) - Convert.ToInt32(filaActual[2]);
                            filaActual[8] = Convert.ToInt32(filaActual[8]);
                            
                            //faltante = Convert.ToInt32(filaActual[8]) - Convert.ToInt32(filaActual[2]);
                            if (faltante < 0)
                            {
                                filaActual[9] = faltante * -1;
                            }
                            else
                            {
                                filaActual[9] = 0;
                            }
                            //filaActual[8] = Convert.ToInt32(filaActual[8]) + Convert.ToInt32(filaActual[7]) - Convert.ToInt32(filaActual[2]);
                            if (Convert.ToInt32(filaActual[8]) < 0)
                            {
                                filaActual[8] = 0;
                            }

                            filaActual[10] = 0;
                            filaActual[11] = Convert.ToInt32(filaActual[8]) * km;
                            filaActual[12] = Convert.ToInt32(filaActual[9]) * ks;
                            filaActual[13] = Convert.ToInt32(filaActual[10]) + Convert.ToInt32(filaActual[11]) + Convert.ToInt32(filaActual[12]);
                            filaActual[14] = Convert.ToInt32(filaActual[13]) + Convert.ToInt32(filaActual[14]);
                            filaActual[15] = Math.Round(Convert.ToDouble(filaActual[14]) / Convert.ToDouble(filaActual[0]), 2);
                        }


                    }





                }






                if (i >= Convert.ToInt32(txt_Desde.Text) && i <= Convert.ToInt32(txt_Desde.Text) + 100)
                {
                    dgTabla1.Rows.Add(filaActual[0], filaActual[1], filaActual[2], filaActual[3], filaActual[4], filaActual[5], filaActual[6], filaActual[7], filaActual[8], filaActual[9], filaActual[10], filaActual[11], filaActual[12], filaActual[13], filaActual[14], filaActual[15]);
                }
                if (i == Convert.ToInt32(txt_Semanas.Text) && Convert.ToInt32(txt_Semanas.Text) > 100)
                {
                    dgTabla1.Rows.Add(filaActual[0], filaActual[1], filaActual[2], filaActual[3], filaActual[4], filaActual[5], filaActual[6], filaActual[7], filaActual[8], filaActual[9], filaActual[10], filaActual[11], filaActual[12], filaActual[13], filaActual[14], filaActual[15]);
                }


            }

            costoProm = Convert.ToDouble(filaActual[15]);
            //res = costoProm;
            lbl_Prom.Text = "Costo Promedio por semana = $" + costoProm;

        }
    }
}
