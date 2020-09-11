using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Juego_del_Gato_IA2020
{
    class ParametrosGatoIA
    {
        private int[,] gato = new int[3, 3];
        private int gana;
        private int[] movIA = new int[3];

        public int[,] gato1
        {
            get => gato;
            set => gato = value;
        }

        public int Gana
        {
            get => gana;
            set => gana = value;
        }
        public int[] MovIA
        {
            get => movIA;
            set => movIA = value;
        }

        public void iniciar()
        {
            
            for(int i = 0; i < gato.GetLength(0); i++)
            
               for(int j = 0; j < gato.GetLength(1); j++)
                
                    gato[i,j] = -1;
                
            Gana = -1;
        }

       

        public void indicadorPosicion(int x, int y)
        {
            if(x >= 0 && x < 3 && y >= 0 && y < 3 && gato[x,y] == -1 && Gana == -1)
            {
                gato[x, y] = 0;
                Gana = ganar();
                Maquina();
            }
        }

        public int ganar()
        {
            int a = -1;

            //Diagonales
            if (gato[0, 0] != -1 && gato[0, 0] == gato[1, 1] && gato[0, 0] == gato[2, 2])
                a = gato[0, 0];

            if (gato[0, 2] != -1 && gato[0, 2] == gato[1, 1] && gato[0, 2] == gato[2, 0])
                a = gato[0, 2];

            //horizontal y vertical
            for (int i = 0; i < gato.GetLength(0); i++)
            {
                if (gato[i, 0] != -1 && gato[i, 0] == gato[i, 1] && gato[i, 0] == gato[i, 2])
                    a = gato[i, 0];

                if (gato[0, i] != -1 && gato[0, i] == gato[1, i] && gato[0, i] == gato[2, i])
                    a = gato[0, i];
            }

            return a;
        }

        public Boolean gatoLleno()
        {
            bool tableroCompleto = true;
            for (int i = 0; i < gato.GetLength(0); i++)
                for (int j = 0; j < gato.GetLength(1); j++)
                    if (gato[i, j] == -1)
                        tableroCompleto = false;


            return tableroCompleto;
        }

        public Boolean finPartida()
        {
            bool finP = false;
            if(gatoLleno() || ganar() != -1)
            {
                finP = true;
            }
            return finP;
        }

        public void Maquina()
        {

            if (!finPartida())
            {

                int f = 0;
                int c = 0;
                int v = -99999999;
                int aux;

                
                for (int i = 0; i < gato.GetLength(0); i++)
                    for (int j = 0; j < gato.GetLength(1); j++)
                        if (gato[i, j] == -1)
                        {
                            gato[i, j] = 1;
                            aux = minimo();
                            if (aux > v)
                            {
                                v = aux;
                                f = i;
                                c = j;
                            }

                            gato[i, j] = -1;
                        }
                gato[f, c] = 1;
                movIA[0] = f;
                movIA[1] = c;
            }


        }

        private int maximo()
        {
            if (finPartida())
            {
                if (ganar() != -1)
                    return -1;
                else
                    return 0;
            }

            int v = -99999999;
            int aux;
            for (int i = 0; i < gato.GetLength(0); i++)
                for (int j = 0; j < gato.GetLength(1); j++)
                    if (gato[i, j] == -1)
                    {
                        gato[i, j] = 1;
                        aux = minimo();
                        if (aux > v)
                            v = aux;

                        gato[i, j] = -1;
                    }

            return v;
        }


        private int minimo()
        {
            if (finPartida())
            {
                if (ganar() != -1)
                    return 1;
                else
                    return 0;
            }

            int v = 99999999;
            int aux;
            for (int i = 0; i < gato.GetLength(0); i++)
                for (int j = 0; j < gato.GetLength(1); j++)
                    if (gato[i, j] == -1)
                    {
                        gato[i, j] = 0;
                        aux = maximo();
                        if (aux < v)
                            v = aux;

                        gato[i, j] = -1;
                    }

            return v;
        }
    }
}
