using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Juego_del_Gato_IA2020
{
    public partial class Form3 : Form
    {
        String nomJug1, nomJug2;
        int r, r1, turno, puntJ1 = 0, puntJ2 = 0, puntEmp = 0;

        SoundPlayer sound1 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\062-Discovery-_1_.wav");
        SoundPlayer sound2 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\087-Game-Over.wav");
        SoundPlayer sound3 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\090-Miss_.wav");
        SoundPlayer sound4 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\40-Labo-System-a-Ciel-_Ciel_s-Mini-Game_ (1).wav");
        SoundPlayer sound5 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\32-Heat-on-Beat-2012-The-Mercenaries.wav");
        SoundPlayer sound6 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\130-Out-of-Cargo.wav");
        SoundPlayer sound7 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\088-Got-a-Spirit-Train-Car_.wav");
        SoundPlayer sound8 = new SoundPlayer(@"C:\Users\Hector\Downloads\Juego del Gato IA\Juego del Gato IA\Juego del Gato IA2020\Recursos\009-Got-a-Small-Item_.wav");

        //32-Heat-on-Beat-2012-The-Mercenaries.wav
        public Form3()
        {
            InitializeComponent();
        }
        
        
        private void btnRandom_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            r = rd.Next(1, 5);
            r1 = rd.Next(1, 5);
            //Thread.Sleep(2000);
            if (r > r1)
            {
                lbEscg.Text = "Escoge e inicia: ";
                lbEscJug.Text = nomJug1;
                turno = 1;
                lbSelecciona.Enabled = true;
                btnRandom.Enabled = false;
                rbX.Enabled = true;
                rbO.Enabled = true;
            }
            else
            {
                if(r1 > r)
                {
                    lbEscg.Text = "Escoge e inicia: ";
                    lbEscJug.Text = nomJug2;
                    turno = 4;
                    lbSelecciona1.Enabled = true;
                    btnRandom.Enabled = false;
                    rbX1.Enabled = true;
                    rbO1.Enabled = true;
                }
                else
                {
                    if(r == r1 || r1 == r)
                    {
                        r = rd.Next(1, 5);
                        r1 = rd.Next(1, 5);
                    }
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void rbX_CheckedChanged(object sender, EventArgs e)
        {
            if(rbX.Checked == true)
            {
                rbO1.Select();
                
            }
            btnIniciar.Enabled = true;
        }
        private void rbO_CheckedChanged(object sender, EventArgs e)
        {
            if (rbO.Checked == true)
            {
                rbX1.Select();
                
            }
            btnIniciar.Enabled = true;
        }
        private void rbX1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbX1.Checked == true)
            {
                rbO.Select();
                
            }
            btnIniciar.Enabled = true;
        }
        private void rbO1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbO1.Checked == true)
            {
                rbX.Select();
            }
            btnIniciar.Enabled = true;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            sound1.Play();
            Thread.Sleep(1200);
            MessageBox.Show("¡Inicia juego!", "En marcha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            sound5.PlayLooping();
            lbEscg.Text = "";
            lbEscJug.Text = "";
            label3.Text = "";
            lbNombre.Text = nomJug1;
            lbNombreIA.Text = nomJug2;
            lbEmpate.Text = "Empate";
            lbPuntUsuar.Text = "0";
            lbPuntIntel.Text = "0";
            lbPuntEmp.Text = "0";
            btnIniciar.Enabled = false;
            btnReiniciar.Enabled = true;
            btnTerminar.Enabled = true;
            if(rbX.Checked == true)
            {
                rbO1.Enabled = true;
                rbX1.Enabled = false;
            }
            if(rbO.Checked == true)
            {
                rbX1.Enabled = true;
                rbO1.Enabled = false;
            }
            if(rbX1.Checked == true)
            {
                rbO.Enabled = true;
                rbX.Enabled = false;
            }
            if(rbO1.Checked == true)
            {
                rbX.Enabled = true;
                rbO.Enabled = false;
            }
            habilitarBotones();
            
        }

        private void b1_Click(object sender, EventArgs e)
        {
            b1.Enabled = false;
            switch (turno)
            {
                case 1:
                    if (rbX.Checked == true)
                    {
               
                        b1.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();
                        
                    }

                    if (rbO.Checked == true)
                    {
                        
                        b1.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 2:
                    if (rbX1.Checked == true)
                    {
                        
                        b1.Text = "X";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {
                        
                        b1.Text = "O";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 4:
                    if (rbX1.Checked == true)
                    {
                        
                        b1.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {
                       
                        b1.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 5:
                    if (rbX.Checked == true)
                    {
                        
                        b1.Text = "X";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {
                        b1.Text = "O";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }
                    break;
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            b2.Enabled = false;
            switch (turno)
            {
                case 1:
                    if (rbX.Checked == true)
                    {

                        b2.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {

                        b2.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 2:
                    if (rbX1.Checked == true)
                    {

                        b2.Text = "X";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b2.Text = "O";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 4:
                    if (rbX1.Checked == true)
                    {

                        b2.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b2.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 5:
                    if (rbX.Checked == true)
                    {

                        b2.Text = "X";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {
                        b2.Text = "O";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }
                    break;
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            b3.Enabled = false;
            switch (turno)
            {
                case 1:
                    if (rbX.Checked == true)
                    {

                        b3.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {

                        b3.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 2:
                    if (rbX1.Checked == true)
                    {

                        b3.Text = "X";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b3.Text = "O";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 4:
                    if (rbX1.Checked == true)
                    {

                        b3.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b3.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 5:
                    if (rbX.Checked == true)
                    {

                        b3.Text = "X";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {
                        b3.Text = "O";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }
                    break;
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {
            b4.Enabled = false;
            switch (turno)
            {
                case 1:
                    if (rbX.Checked == true)
                    {

                        b4.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {

                        b4.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 2:
                    if (rbX1.Checked == true)
                    {

                        b4.Text = "X";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b4.Text = "O";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 4:
                    if (rbX1.Checked == true)
                    {

                        b4.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b4.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 5:
                    if (rbX.Checked == true)
                    {

                        b4.Text = "X";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {
                        b4.Text = "O";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }
                    break;
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            b5.Enabled = false;
            switch (turno)
            {
                case 1:
                    if (rbX.Checked == true)
                    {

                        b5.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {

                        b5.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 2:
                    if (rbX1.Checked == true)
                    {

                        b5.Text = "X";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b5.Text = "O";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 4:
                    if (rbX1.Checked == true)
                    {

                        b5.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b5.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 5:
                    if (rbX.Checked == true)
                    {

                        b5.Text = "X";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {
                        b5.Text = "O";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }
                    break;
            }
        }

        private void b6_Click(object sender, EventArgs e)
        {
            b6.Enabled = false;
            switch (turno)
            {
                case 1:
                    if (rbX.Checked == true)
                    {

                        b6.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {

                        b6.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 2:
                    if (rbX1.Checked == true)
                    {

                        b6.Text = "X";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b6.Text = "O";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 4:
                    if (rbX1.Checked == true)
                    {

                        b6.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b6.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 5:
                    if (rbX.Checked == true)
                    {

                        b6.Text = "X";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {
                        b6.Text = "O";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }
                    break;
            }
        }

        private void b7_Click(object sender, EventArgs e)
        {
            b7.Enabled = false;
            switch (turno)
            {
                case 1:
                    if (rbX.Checked == true)
                    {

                        b7.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {

                        b7.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 2:
                    if (rbX1.Checked == true)
                    {

                        b7.Text = "X";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b7.Text = "O";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 4:
                    if (rbX1.Checked == true)
                    {

                        b7.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b7.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 5:
                    if (rbX.Checked == true)
                    {

                        b7.Text = "X";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {
                        b7.Text = "O";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }
                    break;
            }
        }

        private void b8_Click(object sender, EventArgs e)
        {
            b8.Enabled = false;
            switch (turno)
            {
                case 1:
                    if (rbX.Checked == true)
                    {

                        b8.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {

                        b8.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 2:
                    if (rbX1.Checked == true)
                    {

                        b8.Text = "X";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b8.Text = "O";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 4:
                    if (rbX1.Checked == true)
                    {

                        b8.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b8.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 5:
                    if (rbX.Checked == true)
                    {

                        b8.Text = "X";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {
                        b8.Text = "O";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }
                    break;
            }
        }

        private void b9_Click(object sender, EventArgs e)
        {
            b9.Enabled = false;
            switch (turno)
            {
                case 1:
                    if (rbX.Checked == true)
                    {

                        b9.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {

                        b9.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 2:
                    if (rbX1.Checked == true)
                    {

                        b9.Text = "X";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b9.Text = "O";
                        ganador();
                        turno = 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 4:
                    if (rbX1.Checked == true)
                    {

                        b9.Text = "X";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }

                    if (rbO1.Checked == true)
                    {

                        b9.Text = "O";
                        ganador();
                        turno = turno + 1;
                        label3.Text = turno.ToString();

                    }
                    break;
                case 5:
                    if (rbX.Checked == true)
                    {

                        b9.Text = "X";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }

                    if (rbO.Checked == true)
                    {
                        b9.Text = "O";
                        ganador();
                        turno = 4;
                        label3.Text = turno.ToString();

                    }
                    break;
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea terminar el juego?", "Terminar juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(opcion == DialogResult.Yes)
            {
                deshabilitaBorrar();
                turno = 0;
                lbGanador.Text = "";
                nomJug1 = "";
                nomJug2 = "";
                lbEscg.Text = "";
                lbEscJug.Text = "";
                lbEmpate.Text = "-";
                lbGanador.Text = "";
                lbPuntEmp.Text = "-";
                lbNombre.Text = "-";
                lbPuntUsuar.Text = "-";
                lbNombreIA.Text = "-";
                lbPuntIntel.Text = "-";
                lbJug1.Text = "-";
                lbjug2.Text = "-";
                label3.Text = "Ingrese nombre de jugadores";
                label4.Text = "";
                lbSelecciona.Enabled = false;
                lbSelecciona1.Enabled = false;
                rbX.Enabled = false;
                rbO.Enabled = false;
                rbX1.Enabled = false;
                rbO1.Enabled = false;
                rbX.Checked = false;
                rbO.Checked = false;
                rbX1.Checked = false;
                rbO1.Checked = false;
                puntJ1 = 0;
                puntJ2 = 0;
                puntEmp = 0;
                btnIniciar.Enabled = false;
                btnReiniciar.Enabled = false;
                btnRandom.Enabled = false;
                btnTerminar.Enabled = false;
                btnIngresar.Enabled = true;
                sound1.Play();
            }

        }

        private void ganador()
        {

            if(turno == 1)
            {
                if(rbX.Checked == true)
                {
                    if(b1.Text == "X" && b2.Text == "X" && b3.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 1;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if(opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno =  turno - 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b1.Text == "X" && b4.Text == "X" && b7.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 1;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b1.Text == "X" && b5.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 1;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b2.Text == "X" && b5.Text == "X" && b8.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 1;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b3.Text == "X" && b6.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 1;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b4.Text == "X" && b5.Text == "X" && b6.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 1;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b7.Text == "X" && b8.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 1;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                }
                else
                {
                    if(rbO.Checked == true)
                    {
                        if (b1.Text == "O" && b2.Text == "O" && b3.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 1;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b1.Text == "O" && b4.Text == "O" && b7.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 1;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b1.Text == "O" && b5.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 1;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b2.Text == "O" && b5.Text == "O" && b8.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 1;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b3.Text == "O" && b6.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 1;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b4.Text == "O" && b5.Text == "O" && b6.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 1;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b7.Text == "O" && b8.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 1;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                    }
                }
            }
            if(turno == 2)
            {
                if (rbX1.Checked == true)
                {
                    if (b1.Text == "X" && b2.Text == "X" && b3.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 1;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b1.Text == "X" && b4.Text == "X" && b7.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 1;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b1.Text == "X" && b5.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 1;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b2.Text == "X" && b5.Text == "X" && b8.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 1;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b3.Text == "X" && b6.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 1;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b4.Text == "X" && b5.Text == "X" && b6.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 1;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b7.Text == "X" && b8.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 1;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 1;
                                sound5.PlayLooping();
                            }
                        }
                    }
                }
                else
                {
                    if (rbO1.Checked == true)
                    {
                        if (b1.Text == "O" && b2.Text == "O" && b3.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 1;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b1.Text == "O" && b4.Text == "O" && b7.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 1;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b1.Text == "O" && b5.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 1;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b2.Text == "O" && b5.Text == "O" && b8.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 1;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b3.Text == "O" && b6.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 1;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b4.Text == "O" && b5.Text == "O" && b6.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 1;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b7.Text == "O" && b8.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 1;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 1;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                    }
                }

            }
            if (turno == 4)
            {
                if (rbX1.Checked == true)
                {
                    if (b1.Text == "X" && b2.Text == "X" && b3.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 4;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b1.Text == "X" && b4.Text == "X" && b7.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 4;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b1.Text == "X" && b5.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 4;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b2.Text == "X" && b5.Text == "X" && b8.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 4;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b3.Text == "X" && b6.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 4;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b4.Text == "X" && b5.Text == "X" && b6.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 4;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b7.Text == "X" && b8.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ2 += 1;
                        lbPuntIntel.Text = puntJ2.ToString();
                        turno = 4;
                        if (puntJ2 >= 0 && puntJ2 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                }
                else
                {
                    if (rbO1.Checked == true)
                    {
                        if (b1.Text == "O" && b2.Text == "O" && b3.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 4;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b1.Text == "O" && b4.Text == "O" && b7.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 4;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b1.Text == "O" && b5.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 4;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b2.Text == "O" && b5.Text == "O" && b8.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 4;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b3.Text == "O" && b6.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 4;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b4.Text == "O" && b5.Text == "O" && b6.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 4;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b7.Text == "O" && b8.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug2 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ2 += 1;
                            lbPuntIntel.Text = puntJ2.ToString();
                            turno = 4;
                            if (puntJ2 >= 0 && puntJ2 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                    }
                }
            }
            if (turno == 5)
            {
                if (rbX.Checked == true)
                {
                    if (b1.Text == "X" && b2.Text == "X" && b3.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 4;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b1.Text == "X" && b4.Text == "X" && b7.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 4;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b1.Text == "X" && b5.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 4;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b2.Text == "X" && b5.Text == "X" && b8.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 4;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b3.Text == "X" && b6.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 4;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b4.Text == "X" && b5.Text == "X" && b6.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 4;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                    if (b7.Text == "X" && b8.Text == "X" && b9.Text == "X")
                    {
                        DialogResult opc;
                        sound7.Play();
                        btnReiniciar.Enabled = false;
                        btnTerminar.Enabled = false;
                        MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        puntJ1 += 1;
                        lbPuntUsuar.Text = puntJ1.ToString();
                        turno = 4;
                        if (puntJ1 >= 0 && puntJ1 <= 4)
                        {
                            Thread.Sleep(1000);
                            opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (opc == DialogResult.OK)
                            {
                                habilitarBotones();
                                btnReiniciar.Enabled = true;
                                btnTerminar.Enabled = true;
                                turno = 4;
                                sound5.PlayLooping();
                            }
                        }
                    }
                }
                else
                {
                    if (rbO.Checked == true)
                    {
                        if (b1.Text == "O" && b2.Text == "O" && b3.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 4;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b1.Text == "O" && b4.Text == "O" && b7.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 4;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b1.Text == "O" && b5.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 4;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b2.Text == "O" && b5.Text == "O" && b8.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 4;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b3.Text == "O" && b6.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 4;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b4.Text == "O" && b5.Text == "O" && b6.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 4;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                        if (b7.Text == "O" && b8.Text == "O" && b9.Text == "O")
                        {
                            DialogResult opc;
                            sound7.Play();
                            btnReiniciar.Enabled = false;
                            btnTerminar.Enabled = false;
                            MessageBox.Show("Gana " + nomJug1 + " +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntJ1 += 1;
                            lbPuntUsuar.Text = puntJ1.ToString();
                            turno = 4;
                            if (puntJ1 >= 0 && puntJ1 <= 4)
                            {
                                Thread.Sleep(1000);
                                opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, toca turno para iniciar el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (opc == DialogResult.OK)
                                {
                                    habilitarBotones();
                                    btnReiniciar.Enabled = true;
                                    btnTerminar.Enabled = true;
                                    turno = 4;
                                    sound5.PlayLooping();
                                }
                            }
                        }
                    }
                }
            }

            if(b1.Text != "" && b2.Text != "" && b3.Text != "" && b4.Text != "" && b5.Text != "" && b6.Text != "" && b7.Text != "" && b8.Text != "" && b9.Text != "")
            {
                DialogResult opc;
                sound6.Play();
                btnReiniciar.Enabled = false;
                btnTerminar.Enabled = false;
                MessageBox.Show("Empate +1", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                puntEmp += 1;
                lbPuntEmp.Text = puntEmp.ToString();
                if (puntEmp >= 0 && puntEmp <= 9)
                {
                    Thread.Sleep(1000);
                    opc = MessageBox.Show("Se limpiara el tablero para la siguiente ronda, siguiente turno para el otro jugador!", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (opc == DialogResult.OK)
                    {
                        habilitarBotones();
                        btnReiniciar.Enabled = true;
                        btnTerminar.Enabled = true;
                        if (r > r1)
                        {
                            turno = 1;
                            
                        }
                        if (r1 > r)
                        {
                            turno = 4;
                            
                        }
                        sound5.PlayLooping();
                    }
                }
            }

            if(puntJ1 == 5)
            {
                deshabilitarBotones();
                sound5.Stop();
                sound8.Play();
                DialogResult opc;
                lbGanador.Text = "El ganador de la partida: " + nomJug1;
                opc = MessageBox.Show("Juego terminado, si desea continuar puede reiniciar o terminar la partida para jugar con diferente icono", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (opc == DialogResult.OK)
                {
                    sound1.Play();
                }

                btnReiniciar.Enabled = true;
                btnTerminar.Enabled = true;
            }

            if(puntJ2 == 5)
            {
                deshabilitarBotones();
                sound5.Stop();
                sound8.Play();
                DialogResult opc;
                lbGanador.Text = "El ganador de la partida: " + nomJug2;
                opc = MessageBox.Show("Juego terminado, si desea continuar puede reiniciar o terminar la partida para jugar con diferente icono", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (opc == DialogResult.OK)
                {
                    sound1.Play();
                }

                btnReiniciar.Enabled = true;
                btnTerminar.Enabled = true;
            }

            if(puntJ1 == 5 && puntJ2 == 5)
            {
                deshabilitarBotones();
                sound5.Stop();
                sound6.Play();
                DialogResult opc;
                lbGanador.Text = "¡Es un doble empate!";
                opc = MessageBox.Show("Juego empatado, si desea continuar puede reiniciar o terminar la partida para jugar con diferente icono", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (opc == DialogResult.OK)
                {
                    sound1.Play();
                }

                btnReiniciar.Enabled = true;
                btnTerminar.Enabled = true;
            }

            if(puntEmp == 10)
            {
                deshabilitarBotones();
                sound5.Stop();
                sound2.Play();
                Thread.Sleep(12000);
                DialogResult opc;
                lbGanador.Text = "Se llego al limite de intentos";
                opc = MessageBox.Show("Juego terminado, si desea continuar puede reiniciar o terminar la partida para jugar con diferente icono", "Juego dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (opc == DialogResult.OK)
                {
                    sound1.Play();
                }

                btnReiniciar.Enabled = true;
                btnTerminar.Enabled = true;
            }

            if (puntEmp == 10 && puntJ1 > puntJ2)
            {
                deshabilitarBotones();
                sound5.Stop();
                sound8.Play();
                
                lbGanador.Text = "Se llego al limite de intentos";
                label4.Text = "Ganador por mayoria: " + nomJug1;

                btnReiniciar.Enabled = true;
                btnTerminar.Enabled = true;
            }

            if (puntEmp == 10 && puntJ2 > puntJ1)
            {
                deshabilitarBotones();
                sound5.Stop();
                sound8.Play();
                
                lbGanador.Text = "Se llego al limite de intentos";
                label4.Text = "Ganador por mayoria: " + nomJug2;

                btnReiniciar.Enabled = true;
                btnTerminar.Enabled = true;
            }


        }

        private void mnGatoIA_Click(object sender, EventArgs e)
        {
            sound5.Stop();
            sound1.Play();
            Form2 fd = new Form2();
            this.Hide();
            fd.ShowDialog();
            this.Close();
        }

        private void mnSalir_Click(object sender, EventArgs e)
        {
            sound5.Stop();
            sound1.Play();
            Thread.Sleep(1200);
            Close();
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea reiniciar el juego?, en caso de ser si, el que inicia el juego es el jugador que salio en el random! ", "Reiniciar el juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(opcion == DialogResult.Yes)
            {
                sound5.PlayLooping();
                int ra = r, rb = r1;
                if (ra > rb)
                {
                    habilitarBotones();
                    turno = 1;
                }
                else
                {
                    if (rb > ra)
                    {
                        habilitarBotones();
                        turno = 4;
                    }
                }
                lbPuntEmp.Text = "0";
                puntEmp = 0;
                lbPuntUsuar.Text = "0";
                puntJ1 = 0;
                lbPuntIntel.Text = "0";
                puntJ2 = 0;
                lbGanador.Text = "";
                label4.Text = "";
            }
            
        }

        private void lbjug2_Click(object sender, EventArgs e)
        {
            
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            sound1.Play();
            Thread.Sleep(1200);
            sound4.PlayLooping();
            nomJug1 = Interaction.InputBox("Ingrese el nombre del jugador 1");
            if (String.IsNullOrEmpty(nomJug1))
            {
                MessageBox.Show("No se registro nada, ingrese su nombre por favor", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nomJug1 = Interaction.InputBox("Ingrese el nombre del jugador 1");
            }
            nomJug2 = Interaction.InputBox("Ingrese el nombre del jugador 2");
            if (String.IsNullOrEmpty(nomJug1))
            {
                MessageBox.Show("No se registro nada, ingrese su nombre por favor", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nomJug2 = Interaction.InputBox("Ingrese el nombre del jugador 2");
            }
            else
            {
                MessageBox.Show("Bienvenidos jugadores "+nomJug1+" y "+nomJug2, "Bienvenidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            lbJug1.Text = nomJug1;
            lbjug2.Text = nomJug2;
            btnIngresar.Enabled = false;
            btnRandom.Enabled = true;
        }

        private void habilitarBotones()
        {
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
        }

        private void deshabilitarBotones()
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
        }

        private void deshabilitaBorrar()
        {
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
        }


    }



}
