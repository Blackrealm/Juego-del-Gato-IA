using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.IO;

namespace Juego_del_Gato_IA2020
{
    public partial class Form2 : Form
    {
        string nombreJugador;
        ParametrosGatoIA cat = new ParametrosGatoIA();
        private int[,] gat = new int[2, 2];
        private int gana = -1;
        int puntajeUsuario = 0;
        int puntajeInteligencia = 0;
        int puntajeEmpate = 0;
        SoundPlayer sound1 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\062-Discovery-_1_.wav");
        SoundPlayer sound2 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\087-Game-Over.wav");
        SoundPlayer sound3 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\090-Miss_.wav");
        SoundPlayer sound4 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\40-Labo-System-a-Ciel-_Ciel_s-Mini-Game_ (1).wav");
        public Form2()
        {
            InitializeComponent();
            cat.iniciar();
            gat = cat.gato1;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            sound1.Play();
            Thread.Sleep(1200);
            sound4.PlayLooping();
            
                nombreJugador = Interaction.InputBox("Ingrese su nombre por favor");
                if (String.IsNullOrEmpty(nombreJugador))
                {
                    MessageBox.Show("No se registro nada, ingrese su nombre por favor", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nombreJugador = Interaction.InputBox("Ingrese su nombre por favor");
            }
                else
                {
                    MessageBox.Show("Bienvenido " + nombreJugador, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            MessageBox.Show("¡Inicia juego!", "En marcha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            lbNombre.Text = nombreJugador;
            lbNombreIA.Text = "Inteligencia Artificial :)";
            lbEmpate.Text = "Empates";
            lbPuntUsuar.Text = "0";
            lbPuntIntel.Text = "0";
            lbPuntEmp.Text = "0";
            cat.iniciar();
            gat = cat.gato1;
            gana = -1;
            b1.Text = "";
            b1.Enabled = true;
            b2.Text = "";
            b2.Enabled = true;
            b3.Text = "";
            b3.Enabled = true;
            b4.Text = "";
            b4.Enabled = true;
            b5.Text = "";
            b5.Enabled = true;
            b6.Text = "";
            b6.Enabled = true;
            b7.Text = "";
            b7.Enabled = true;
            b8.Text = "";
            b8.Enabled = true;
            b9.Text = "";
            b9.Enabled = true;
            btnIniciar.Enabled = false;
            btnReiniciar.Enabled = true;
            btnTerminar.Enabled = true;
            if (rbX.Checked == true)
            {
                rbO.Enabled = false;
            }
            else
            {
                rbX.Enabled = false;
            }


        }
        private void lbNombre_Click(object sender, EventArgs e)
        {

        }

        private void mnVolver_Click(object sender, EventArgs e)
        {
            sound4.Stop();
            sound1.Play();
            Form3 fs = new Form3();
            this.Hide();
            fs.ShowDialog();
            this.Close();
        }

        private void mnSalir_Click(object sender, EventArgs e)
        {
            sound1.Play();
            Thread.Sleep(1200);
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
                btnIniciar.Enabled = true;
          
        }

        private void eventoX(int x, int y, Button button)
        {
            if(gat[x, y] == -1)
            {
                
               
                cat.indicadorPosicion(x, y);
                gana = cat.ganar();
                //Thread.Sleep(3000);
                button.Text = "X";
                button.Enabled = false;
                comprobarGana();
            }
        }


        private void eventoO(int x, int y, Button button)
        {
            if (gat[x, y] == -1)
            {
                
                
                cat.indicadorPosicion(x, y);
                gana = cat.ganar();
                //Thread.Sleep(3000);
                button.Text = "O";
                button.Enabled = false;
                comprobarGana();
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if(rbX.Checked == true)
            {
                eventoX(0, 0, b1);
            }
            else
            {
                if (rbO.Checked == true)
                    eventoO(0, 0, b1);
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (rbX.Checked == true)
            {
                eventoX(0, 1, b2);
            }
            else
            {
                if (rbO.Checked == true)
                    eventoO(0, 1, b2);
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            if (rbX.Checked == true)
            {
                eventoX(0, 2, b3);
            }
            else
            {
                if (rbO.Checked == true)
                    eventoO(0, 2, b3);
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (rbX.Checked == true)
            {
                eventoX(1, 0, b4);
            }
            else
            {
                if (rbO.Checked == true)
                    eventoO(1, 0, b4);
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            if (rbX.Checked == true)
            {
                eventoX(1, 1, b5);
            }
            else
            {
                if (rbO.Checked == true)
                    eventoO(1, 1, b5);
            }
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (rbX.Checked == true)
            {
                eventoX(1, 2, b6);
            }
            else
            {
                if (rbO.Checked == true)
                    eventoO(1, 2, b6);
            }
        }

        private void b7_Click(object sender, EventArgs e)
        {
            if (rbX.Checked == true)
            {
                eventoX(2, 0, b7);
            }
            else
            {
                if (rbO.Checked == true)
                    eventoO(2, 0, b7);
            }
        }

        private void b8_Click(object sender, EventArgs e)
        {
            if (rbX.Checked == true)
            {
                eventoX(2, 1, b8);
            }
            else
            {
                if (rbO.Checked == true)
                    eventoO(2, 1, b8);
            }
        }

        private void b9_Click(object sender, EventArgs e)
        {
            if (rbX.Checked == true)
            {
                eventoX(2, 2, b9);
            }
            else
            {
                if (rbO.Checked == true)
                    eventoO(2, 2, b9);
            }
        }

        

        private void comprobarGana()
        {
            int[] ultimoMov = cat.MovIA;
            
            if (rbO.Checked == true)
            {
                if(ultimoMov[0] == 0 && ultimoMov[1] == 0)
                {
                  
                    b1.Text = "X";
                    b1.Enabled = false;
                }
                if (ultimoMov[0] == 0 && ultimoMov[1] == 1)
                {
                    
                    b2.Text = "X";
                    b2.Enabled = false;

                }
                if (ultimoMov[0] == 0 && ultimoMov[1] == 2)
                {
                    
                    b3.Text = "X";
                    b3.Enabled = false;
                }

                if (ultimoMov[0] == 1 && ultimoMov[1] == 0)
                {
                    
                    b4.Text = "X";
                    b4.Enabled = false;
                }
                if (ultimoMov[0] == 1 && ultimoMov[1] == 1)
                {
                    
                    b5.Text = "X";
                    b5.Enabled = false;
                }
                if (ultimoMov[0] == 1 && ultimoMov[1] == 2)
                {
                    
                    b6.Text = "X";
                    b6.Enabled = false;
                }

                if (ultimoMov[0] == 2 && ultimoMov[1] == 0)
                {
                    
                    b7.Text = "X";
                    b7.Enabled = false;
                }
                if (ultimoMov[0] == 2 && ultimoMov[1] == 1)
                {
                    
                    b8.Text = "X";
                    b8.Enabled = false;
                }
                if (ultimoMov[0] == 2 && ultimoMov[1] == 2)
                {
                    
                    b9.Text = "X";
                    b9.Enabled = false;
                }

                if(gana == 0)
                {
                    DialogResult opc;
                    sound1.Play();
                    btnReiniciar.Enabled = false;
                    btnTerminar.Enabled = false;
                    MessageBox.Show(nombreJugador+" gana", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    puntajeUsuario = puntajeUsuario + 1;
                    lbPuntUsuar.Text = puntajeUsuario.ToString();
                    Thread.Sleep(1000);
                    if(puntajeUsuario >= 0 && puntajeUsuario <= 4)
                    {
                        opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (opc == DialogResult.OK)
                        {
                            sound1.Play();
                            sound4.PlayLooping();
                            b1.Text = "";
                            b1.Enabled = true;
                            b2.Text = "";
                            b2.Enabled = true;
                            b3.Text = "";
                            b3.Enabled = true;
                            b4.Text = "";
                            b4.Enabled = true;
                            b5.Text = "";
                            b5.Enabled = true;
                            b6.Text = "";
                            b6.Enabled = true;
                            b7.Text = "";
                            b7.Enabled = true;
                            b8.Text = "";
                            b8.Enabled = true;
                            b9.Text = "";
                            b9.Enabled = true;
                            btnReiniciar.Enabled = true;
                            btnTerminar.Enabled = true;
                        }
                        cat.iniciar();
                        gat = cat.gato1;
                        gana = -1;
                    }
       
                }
                if(gana == 1)
                {
                    DialogResult opc;
                    sound3.Play();
                    btnReiniciar.Enabled = false;
                    btnTerminar.Enabled = false;
                    MessageBox.Show("Gana inteligencia artificial", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    puntajeInteligencia = puntajeInteligencia + 1;
                    lbPuntIntel.Text = puntajeInteligencia.ToString();
                    if(puntajeInteligencia >= 0 && puntajeInteligencia <= 4)
                    {
                        Thread.Sleep(1000);
                        opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (opc == DialogResult.OK)
                        {
                            sound1.Play();
                            sound4.PlayLooping();
                            b1.Text = "";
                            b1.Enabled = true;
                            b2.Text = "";
                            b2.Enabled = true;
                            b3.Text = "";
                            b3.Enabled = true;
                            b4.Text = "";
                            b4.Enabled = true;
                            b5.Text = "";
                            b5.Enabled = true;
                            b6.Text = "";
                            b6.Enabled = true;
                            b7.Text = "";
                            b7.Enabled = true;
                            b8.Text = "";
                            b8.Enabled = true;
                            b9.Text = "";
                            b9.Enabled = true;
                            btnReiniciar.Enabled = true;
                            btnTerminar.Enabled = true;
                        }
                        cat.iniciar();
                        gat = cat.gato1;
                        gana = -1;
                    }
                    
                }

                if(gana == -1 && cat.gatoLleno())
                {
                    DialogResult opc;
                    sound3.Play();
                    btnReiniciar.Enabled = false;
                    btnTerminar.Enabled = false;
                    MessageBox.Show("Empate!", "Juego terminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    puntajeEmpate = puntajeEmpate + 1;
                    lbPuntEmp.Text = puntajeEmpate.ToString();
                    if(puntajeEmpate >=0 && puntajeEmpate <= 9)
                    {
                        Thread.Sleep(1000);
                        opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (opc == DialogResult.OK)
                        {
                            sound1.Play();
                            sound4.PlayLooping();
                            b1.Text = "";
                            b1.Enabled = true;
                            b2.Text = "";
                            b2.Enabled = true;
                            b3.Text = "";
                            b3.Enabled = true;
                            b4.Text = "";
                            b4.Enabled = true;
                            b5.Text = "";
                            b5.Enabled = true;
                            b6.Text = "";
                            b6.Enabled = true;
                            b7.Text = "";
                            b7.Enabled = true;
                            b8.Text = "";
                            b8.Enabled = true;
                            b9.Text = "";
                            b9.Enabled = true;
                            btnReiniciar.Enabled = true;
                            btnTerminar.Enabled = true;
                        }
                        cat.iniciar();
                        gat = cat.gato1;
                        gana = -1;
                    }
                    
                }

                if(puntajeUsuario == 5)
                {
                    b1.Enabled = false;
                    b2.Enabled = false;
                    b3.Enabled = false;
                    b4.Enabled = false;
                    b5.Enabled = false;
                    b6.Enabled = false;
                    b7.Enabled = false;
                    b8.Enabled = false;
                    b9.Enabled = false;
                    sound4.Stop();
                    sound1.Play();
                   
                    DialogResult opc;
                    Thread.Sleep(12000);
                    lbGanador.Text = "Ganador de la partida: " + nombreJugador;
                    opc = MessageBox.Show("Juego terminado, si desea continuar puede reiniciar o terminar la partida para jugar con diferente icono", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (opc == DialogResult.OK)
                    {
                        sound1.Play();
                    }
                    
                    btnReiniciar.Enabled = true;
                    btnTerminar.Enabled = true;
                }

                if(puntajeInteligencia == 5)
                {
                    b1.Enabled = false;
                    b2.Enabled = false;
                    b3.Enabled = false;
                    b4.Enabled = false;
                    b5.Enabled = false;
                    b6.Enabled = false;
                    b7.Enabled = false;
                    b8.Enabled = false;
                    b9.Enabled = false;
                    sound4.Stop();
                    sound2.Play();

                    Thread.Sleep(12000);
                    lbGanador.Text = "Ganador de la partida: Inteligencia artificial";
                    DialogResult opc;
                    opc = MessageBox.Show("Juego terminado, si desea continuar puede reiniciar o terminar la partida para jugar con diferente icono", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (opc == DialogResult.OK)
                    {
                        sound1.Play();
                    }
                    
                    btnReiniciar.Enabled = true;
                    btnTerminar.Enabled = true;
                }

                if(puntajeEmpate == 10)
                {
                    b1.Enabled = false;
                    b2.Enabled = false;
                    b3.Enabled = false;
                    b4.Enabled = false;
                    b5.Enabled = false;
                    b6.Enabled = false;
                    b7.Enabled = false;
                    b8.Enabled = false;
                    b9.Enabled = false;
                    sound4.Stop();
                    sound2.Play();
                    
                    DialogResult opc;
                    Thread.Sleep(12000);
                    lbGanador.Text = "Sin ganador, se llego al limite de intentos";
                    opc = MessageBox.Show("Es un empate en 10 rondas!, juego terminado, si desea continuar puede reiniciar o terminar la partida para jugar con diferente icono", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (opc == DialogResult.OK)
                    {
                        sound1.Play();
                    }
                    
                    btnReiniciar.Enabled = true;
                    btnTerminar.Enabled = true;
                }

            }
            else
            {
                if(rbX.Checked == true)
                {
                    if (ultimoMov[0] == 0 && ultimoMov[1] == 0)
                    {
                        
                        b1.Text = "O";
                        b1.Enabled = false;
                    }
                    if (ultimoMov[0] == 0 && ultimoMov[1] == 1)
                    {
                        
                        b2.Text = "O";
                        b2.Enabled = false;
                    }
                    if (ultimoMov[0] == 0 && ultimoMov[1] == 2)
                    {
                        b3.Text = "O";
                        b3.Enabled = false;
                    }

                    if (ultimoMov[0] == 1 && ultimoMov[1] == 0)
                    {
                        
                        b4.Text = "O";
                        b4.Enabled = false;
                    }
                    if (ultimoMov[0] == 1 && ultimoMov[1] == 1)
                    {
                        
                        b5.Text = "O";
                        b5.Enabled = false;
                    }
                    if (ultimoMov[0] == 1 && ultimoMov[1] == 2)
                    {
                        
                        b6.Text = "O";
                        b6.Enabled = false;
                    }

                    if (ultimoMov[0] == 2 && ultimoMov[1] == 0)
                    {
                        
                        b7.Text = "O";
                        b7.Enabled = false;
                    }
                    if (ultimoMov[0] == 2 && ultimoMov[1] == 1)
                    {
                        
                        b8.Text = "O";
                        b8.Enabled = false;
                    }
                    if (ultimoMov[0] == 2 && ultimoMov[1] == 2)
                    {
                        
                        b9.Text = "O";
                        b9.Enabled = false;
                    }

                    if (gana == 0)
                    {
                        DialogResult opc;
                        sound3.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show(nombreJugador + " gana", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntajeUsuario = puntajeUsuario + 1;
                        lbPuntUsuar.Text = puntajeUsuario.ToString();
                        if(puntajeUsuario >= 0 && puntajeUsuario <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                sound1.Play();
                                sound4.PlayLooping();
                                b1.Text = "";
                                b1.Enabled = true;
                                b2.Text = "";
                                b2.Enabled = true;
                                b3.Text = "";
                                b3.Enabled = true;
                                b4.Text = "";
                                b4.Enabled = true;
                                b5.Text = "";
                                b5.Enabled = true;
                                b6.Text = "";
                                b6.Enabled = true;
                                b7.Text = "";
                                b7.Enabled = true;
                                b8.Text = "";
                                b8.Enabled = true;
                                b9.Text = "";
                                b9.Enabled = true;
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                            }
                            cat.iniciar();
                            gat = cat.gato1;
                            gana = -1;
                        }
                        

                    }
                    if (gana == 1)
                    {
                        DialogResult opc;
                        sound3.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana inteligencia artificial", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntajeInteligencia = puntajeInteligencia + 1;
                        lbPuntIntel.Text = puntajeInteligencia.ToString();
                        if (puntajeInteligencia >=0 && puntajeInteligencia <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                sound1.Play();
                                sound4.PlayLooping();
                                b1.Text = "";
                                b1.Enabled = true;
                                b2.Text = "";
                                b2.Enabled = true;
                                b3.Text = "";
                                b3.Enabled = true;
                                b4.Text = "";
                                b4.Enabled = true;
                                b5.Text = "";
                                b5.Enabled = true;
                                b6.Text = "";
                                b6.Enabled = true;
                                b7.Text = "";
                                b7.Enabled = true;
                                b8.Text = "";
                                b8.Enabled = true;
                                b9.Text = "";
                                b9.Enabled = true;
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                            }
                            cat.iniciar();
                            gat = cat.gato1;
                            gana = -1;
                        }
                        

                    }

                    if (gana == -1 && cat.gatoLleno())
                    {
                        DialogResult opc;
                        sound3.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Empate!", "Juego terminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        puntajeEmpate = puntajeEmpate + 1;
                        lbPuntEmp.Text = puntajeEmpate.ToString();
                        if (puntajeEmpate >=0 && puntajeEmpate <= 9)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                sound1.Play();
                                sound4.PlayLooping();
                                b1.Text = "";
                                b1.Enabled = true;
                                b2.Text = "";
                                b2.Enabled = true;
                                b3.Text = "";
                                b3.Enabled = true;
                                b4.Text = "";
                                b4.Enabled = true;
                                b5.Text = "";
                                b5.Enabled = true;
                                b6.Text = "";
                                b6.Enabled = true;
                                b7.Text = "";
                                b7.Enabled = true;
                                b8.Text = "";
                                b8.Enabled = true;
                                b9.Text = "";
                                b9.Enabled = true;
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                            }
                            cat.iniciar();
                            gat = cat.gato1;
                            gana = -1;
                        }

                    }

                    if (puntajeUsuario == 5)
                    {
                        b1.Enabled = false;
                        b2.Enabled = false;
                        b3.Enabled = false;
                        b4.Enabled = false;
                        b5.Enabled = false;
                        b6.Enabled = false;
                        b7.Enabled = false;
                        b8.Enabled = false;
                        b9.Enabled = false;
                        sound4.Stop();
                        sound1.Play();

                        Thread.Sleep(12000);
                        lbGanador.Text = "Ganador de la partida: " + nombreJugador;
                        DialogResult opc;
                       opc = MessageBox.Show("Juego terminado, si desea continuar puede reiniciar o terminar la partida para jugar con diferente icono", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        if(opc == DialogResult.OK){
                            
                            sound1.Play();
                        }
                        
                        btnReiniciar.Enabled = true;
                        btnTerminar.Enabled = true;


                    }

                    if (puntajeInteligencia == 5)
                    {
                        b1.Enabled = false;
                        b2.Enabled = false;
                        b3.Enabled = false;
                        b4.Enabled = false;
                        b5.Enabled = false;
                        b6.Enabled = false;
                        b7.Enabled = false;
                        b8.Enabled = false;
                        b9.Enabled = false;
                        sound4.Stop();
                        sound2.Play();
                        Thread.Sleep(12000);
                        lbGanador.Text = "Ganador de la partida: Inteligencia artificial";
                        DialogResult opc;
                        opc = MessageBox.Show("Juego terminado, si desea continuar puede reiniciar o terminar la partida para jugar con diferente icono", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (opc == DialogResult.OK)
                        {
                            sound1.Play();
                        }
                        
                        btnReiniciar.Enabled = true;
                        btnTerminar.Enabled = true;


                    }

                    if (puntajeEmpate == 10)
                    {
                        b1.Enabled = false;
                        b2.Enabled = false;
                        b3.Enabled = false;
                        b4.Enabled = false;
                        b5.Enabled = false;
                        b6.Enabled = false;
                        b7.Enabled = false;
                        b8.Enabled = false;
                        b9.Enabled = false;
                        sound4.Stop();
                        sound2.Play();
                        
                        Thread.Sleep(12000);
                        lbGanador.Text = "Sin ganador, se llego al limite de intentos";
                        DialogResult opc;
                        opc = MessageBox.Show("Es un empate en 10 rondas!, juego terminado, si desea continuar puede reiniciar o terminar la partida para jugar con diferente icono", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (opc == DialogResult.OK)
                        {
                            sound1.Play();
                        }
                        
                        btnReiniciar.Enabled = true;
                        btnTerminar.Enabled = true;


                    }

                }
            }
        }

        private void rbO_CheckedChanged(object sender, EventArgs e)
        {
            btnIniciar.Enabled = true;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea reiniciar el juego?", "Reiniciar el juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(opcion == DialogResult.Yes)
            {
                sound4.PlayLooping();
                puntajeUsuario = 0;
                puntajeInteligencia = 0;
                puntajeEmpate = 0;
                lbPuntUsuar.Text = "0";
                lbPuntIntel.Text = "0";
                lbPuntEmp.Text = "0";
                lbGanador.Text = "";
                b1.Text = "";
                b1.Enabled = true;
                b2.Text = "";
                b2.Enabled = true;
                b3.Text = "";
                b3.Enabled = true;
                b4.Text = "";
                b4.Enabled = true;
                b5.Text = "";
                b5.Enabled = true;
                b6.Text = "";
                b6.Enabled = true;
                b7.Text = "";
                b7.Enabled = true;
                b8.Text = "";
                b8.Enabled = true;
                b9.Text = "";
                b9.Enabled = true;
                cat.iniciar();
                gat = cat.gato1;
                
            }

        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea terminar el juego?", "Terminar juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(opcion == DialogResult.Yes)
            {
                sound4.Stop();
                sound1.Play();
                b1.Text = "";
                b1.Enabled = false;
                b2.Text = "";
                b2.Enabled = false;
                b3.Text = "";
                b3.Enabled = false;
                b4.Text = "";
                b4.Enabled = false;
                b5.Text = "";
                b5.Enabled = false;
                b6.Text = "";
                b6.Enabled = false;
                b7.Text = "";
                b7.Enabled = false;
                b8.Text = "";
                b8.Enabled = false;
                b9.Text = "";
                b9.Enabled = false;
                btnIniciar.Enabled = true;
                btnReiniciar.Enabled = false;
                rbO.Enabled = true;
                rbX.Enabled = true;
                rbO.Checked = false;
                rbX.Checked = false;
                btnTerminar.Enabled = false;
                lbNombre.Text = "";
                lbNombreIA.Text = "";
                lbPuntUsuar.Text = "";
                lbPuntIntel.Text = "";
                lbPuntEmp.Text = "";
                lbEmpate.Text = "";
                lbGanador.Text = "";
                puntajeUsuario = 0;
                puntajeInteligencia = 0;
                puntajeEmpate = 0;
              
            }
        }
    }
}
