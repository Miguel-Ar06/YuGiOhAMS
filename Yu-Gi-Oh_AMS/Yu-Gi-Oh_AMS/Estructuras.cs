using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Yu_Gi_Oh_AMS
{
    #region Lista Simple y Nodo

    public unsafe struct Nodo<T> where T : class
    {
        private unsafe T Dato;
        public unsafe T dato
        {
            get { return Dato; }
            set { Dato = value; }
        }

        private unsafe Nodo<T>* Siguiente;
        public unsafe Nodo<T>* siguiente
        {
            get { return Siguiente; }
            set { Siguiente = value; }
        }


        private int Indice;
        public int indice
        {
            get { return Indice; }
            set { Indice = value; }
        }

        public unsafe Nodo(T dato)
        {
            this.Dato = dato;
            this.Indice = 0;
            this.Siguiente = null;
        }
    }

    public unsafe class ListaSimple<T> where T : class
    {
        private unsafe Nodo<T>* Cabeza;
        public unsafe Nodo<T>* cabeza
        {
            get { return Cabeza; }
            set { Cabeza = value; }
        }

        private unsafe Nodo<T>* Cola;
        public unsafe Nodo<T>* cola
        {
            get { return Cola; }
            set { Cola = value; }
        }

        private int Tamano;
        public int tamano
        {
            get { return Tamano; }
            set { Tamano = value; }
        }

        public unsafe ListaSimple()
        {
            Cabeza = null;
            Cola = null;
        }

        public unsafe void agregar(T dato)
        {
            Nodo<T>* nuevoNodo = (Nodo<T>*)Marshal.AllocHGlobal(sizeof(Nodo<T>));
            nuevoNodo->dato = dato;
            nuevoNodo->siguiente = null;

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola->siguiente = nuevoNodo;
                cola = nuevoNodo;
            }

            tamano++;
            indexar();
        }

        public unsafe void eliminarPorDato(T dato)
        {
            Nodo<T>* actual = cabeza;
            Nodo<T>* anterior = null;

            while (actual != null)
            {
                if (actual->dato == dato)
                {
                    if (anterior == null)
                    {
                        cabeza = actual->siguiente;
                    }
                    else
                    {
                        anterior->siguiente = actual->siguiente;
                    }

                    tamano--;
                    Marshal.FreeHGlobal((IntPtr)actual);
                    break;
                }

                anterior = actual;
                actual = actual->siguiente;
            }

            indexar();
        }

        public unsafe void eliminarPorIndice(int indice)
        {
            Nodo<T>* actual = cabeza;
            Nodo<T>* anterior = null;

            while (actual != null)
            {
                if (actual->indice == indice)
                {
                    if (anterior == null)
                    {
                        cabeza = actual->siguiente;
                    }
                    else
                    {
                        anterior->siguiente = actual->siguiente;
                    }

                    tamano--;
                    Marshal.FreeHGlobal((IntPtr)actual);
                    break;
                }
                anterior = actual;
                actual = actual->siguiente;
            }

            indexar();
        }

        public unsafe void indexar()
        {
            Nodo<T>* actual = cabeza;
            int indice = 0;

            while (actual != null)
            {
                actual->indice = indice;
                indice++;
                actual = actual->siguiente;
            }
        }

        public unsafe T obtenerDatoPorIndice(int indice)
        {
            Nodo<T>* actual = cabeza;

            while (actual != null)
            {
                if (actual->indice == indice)
                {
                    return actual->dato;
                }
                actual = actual->siguiente;
            }
            return null;
        }

        public unsafe int obtenerIndicePorDato(T dato)
        {
            Nodo<T>* actual = cabeza;

            while (actual != null)
            {
                if (actual->dato == dato)
                {
                    return actual->indice;
                }
                actual = actual->siguiente;
            }
            return -1;
        }
    }

    #endregion

    #region Lista doble y nodo

    public unsafe struct NodoDoble<T> where T : class
    {
        private unsafe T Dato;
        public unsafe T dato
        {
            get { return Dato; }
            set { Dato = value; }
        }

        private unsafe NodoDoble<T>* Anterior;
        public unsafe NodoDoble<T>* anterior
        {
            get { return Anterior; }
            set { Anterior = value; }
        }

        private unsafe NodoDoble<T>* Siguiente;
        public unsafe NodoDoble<T>* siguiente
        {
            get { return Siguiente; }
            set { Siguiente = value; }
        }

        private int Indice;
        public int indice
        {
            get { return Indice; }
            set { Indice = value; }
        }

        public unsafe NodoDoble(T dato)
        {
            this.Dato = dato;
            this.Anterior = null;
            this.Siguiente = null;
            Indice = 0;
        }
    }

    public unsafe class ListaDoble<T> where T : class
    {
        private unsafe NodoDoble<T>* Cabeza;
        public unsafe NodoDoble<T>* cabeza
        {
            get { return Cabeza; }
            set { Cabeza = value; }
        }

        private unsafe NodoDoble<T>* Cola;
        public unsafe NodoDoble<T>* cola
        {
            get { return Cola; }
            set { Cola = value; }
        }

        private int Tamano;
        public int tamano
        {
            get { return Tamano; }
            set { Tamano = value; }
        }

        public unsafe ListaDoble()
        {
            Cabeza = null;
            Cola = null;
        }
        public unsafe void agregar(T dato)
        {
            NodoDoble<T>* nuevoNodo = (NodoDoble<T>*)Marshal.AllocHGlobal(sizeof(NodoDoble<T>));
            nuevoNodo->dato = dato;
            nuevoNodo->anterior = null;
            nuevoNodo->siguiente = null;

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola->siguiente = nuevoNodo;
                nuevoNodo->anterior = cola;
                cola = nuevoNodo;
            }

            tamano++;
            indexar();
        }
        public unsafe void agregarEnPosicion(T dato, int posicion)
        {
            NodoDoble<T>* nuevoNodo = (NodoDoble<T>*)Marshal.AllocHGlobal(sizeof(NodoDoble<T>));
            nuevoNodo->dato = dato;
            nuevoNodo->anterior = null;
            nuevoNodo->siguiente = null;

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                NodoDoble<T>* actual = cabeza;
                NodoDoble<T>* anterior = null;
                int indice = 0;

                while (actual != null)
                {
                    if (indice == posicion)
                    {
                        if (anterior == null)
                        {
                            nuevoNodo->siguiente = actual;
                            actual->anterior = nuevoNodo;
                            cabeza = nuevoNodo;
                        }
                        else
                        {
                            anterior->siguiente = nuevoNodo;
                            nuevoNodo->anterior = anterior;
                            nuevoNodo->siguiente = actual;
                            actual->anterior = nuevoNodo;
                        }
                        break;
                    }
                    anterior = actual;
                    actual = actual->siguiente;
                    indice++;
                }
            }

            tamano++;
            indexar();
        }
        public unsafe void eliminarPorDato(T dato)
        {
            NodoDoble<T>* actual = cabeza;
            NodoDoble<T>* anterior = null;

            while (actual != null)
            {
                if (actual->dato == dato)
                {
                    if (anterior == null)
                    {
                        cabeza = actual->siguiente;
                        if (actual->siguiente != null)
                        {
                            actual->siguiente->anterior = null;
                        }
                    }
                    else
                    {
                        anterior->siguiente = actual->siguiente;
                        if (actual->siguiente != null)
                        {
                            actual->siguiente->anterior = anterior;
                        }
                    }

                    tamano--;
                    Marshal.FreeHGlobal((IntPtr)actual);
                    break;
                }

                anterior = actual;
                actual = actual->siguiente;
            }

            indexar();
        }

        public unsafe void eliminarPorIndice(int indice)
        {
            NodoDoble<T>* actual = cabeza;
            NodoDoble<T>* anterior = null;

            while (actual != null)
            {
                if (actual->indice == indice)
                {
                    if (anterior == null)
                    {
                        cabeza = actual->siguiente;
                        actual->siguiente->anterior = null;
                    }
                    else
                    {
                        anterior->siguiente = actual->siguiente;
                        actual->siguiente->anterior = anterior;
                    }

                    tamano--;
                    Marshal.FreeHGlobal((IntPtr)actual);
                    break;
                }

                anterior = actual;
                actual = actual->siguiente;
            }

            indexar();
        }
        public unsafe void indexar()
        {
            NodoDoble<T>* actual = cabeza;
            int indice = 0;

            while (actual != null)
            {
                actual->indice = indice;
                indice++;
                actual = actual->siguiente;
            }
        }
        public unsafe T obtenerDatoPorIndice(int indice)
        {
            NodoDoble<T>* actual = cabeza;

            while (actual != null)
            {
                if (actual->indice == indice)
                {
                    return actual->dato;
                }
                actual = actual->siguiente;
            }
            return null;
        }
        public unsafe int obtenerIndicePorDato(T dato)
        {
            NodoDoble<T>* actual = cabeza;

            while (actual != null)
            {
                if (actual->dato == dato)
                {
                    return actual->indice;
                }
                actual = actual->siguiente;
            }
            return -1;
        }
        public unsafe void revolver()
        {
            Random random = new Random();
            NodoDoble<T>* actual = cabeza;
            NodoDoble<T>* auxiliar = null;
            T datoAuxiliar;
            int indiceAuxiliar;

            while (actual != null)
            {
                auxiliar = cabeza;

                // nos vamos a una posicion x
                for (int i = 0; i < random.Next(0, tamano); i++)
                {
                    auxiliar = auxiliar->siguiente;
                }

                // intercambiamos los datos
                datoAuxiliar = actual->dato;
                indiceAuxiliar = actual->indice;
                actual->dato = auxiliar->dato;
                actual->indice = auxiliar->indice;
                auxiliar->dato = datoAuxiliar;
                auxiliar->indice = indiceAuxiliar;

                // avanzar a a siguiente carta
                actual = actual->siguiente;
            }

            indexar();
        }
    }

    #endregion

    #region Pila
    public unsafe class Pila<T> where T : class
    {
        private unsafe Nodo<T>* Cima;
        public unsafe Nodo<T>* cima
        {
            get { return Cima; }
            set { Cima = value; }
        }

        private unsafe Nodo<T>* Fondo;
        public unsafe Nodo<T>* fondo
        {
            get { return Fondo; }
            set { Fondo = value; }
        }

        private int Tamano;
        public int tamano
        {
            get;
            set;
        }
        public unsafe Pila()
        {
            Cima = null;
            Fondo = null;
            Tamano = 0;
        }

        public unsafe void indexar()
        {
            Nodo<T>* actual = cima;
            int indice = 0;

            while (actual != null)
            {
                actual->indice = indice;
                indice++;
                actual = actual->siguiente;
            }
        }

        public unsafe void apilar(T dato)
        {
            Nodo<T>* nuevoNodo = (Nodo<T>*)Marshal.AllocHGlobal(sizeof(Nodo<T>));
            nuevoNodo->dato = dato;
            nuevoNodo->siguiente = null;

            if (cima == null)
            {
                cima = nuevoNodo;
                fondo = nuevoNodo;
            }
            else
            {
                nuevoNodo->siguiente = cima;
                cima = nuevoNodo;
            }

            tamano++;
            indexar();
        }

        public unsafe T desapilar()
        {
            if (cima == null)
            {
                return null;
            }

            Nodo<T>* nodoDesapilado = cima;
            cima = cima->siguiente;

            tamano--;
            indexar();

            return nodoDesapilado->dato;
        }

        public unsafe T obtenerCima()
        {
            return cima->dato;
        }

        public unsafe T obtenerFondo()
        {
            return fondo->dato;
        }

        public unsafe T obtenerDatoPorIndice(int indice)
        {
            Nodo<T>* actual = cima;

            while (actual != null)
            {
                if (actual->indice == indice)
                {
                    return actual->dato;
                }
                actual = actual->siguiente;
            }

            return null;
        }

        public unsafe T extraer(int indice)
        {
            Nodo<T>* actual = cima;
            Nodo<T>* anterior = null;

            while (actual != null)
            {
                if (actual->indice == indice)
                {
                    if (anterior == null)
                    {
                        cima = actual->siguiente;
                    }
                    else
                    {
                        anterior->siguiente = actual->siguiente;
                    }

                    tamano--;
                    return actual->dato;
                }

                anterior = actual;
                actual = actual->siguiente;
            }

            indexar();
            return null;
        }

        public unsafe void insertarEnPosicion(T dato, int indice)
        {
            Nodo<T>* nuevoNodo = (Nodo<T>*)Marshal.AllocHGlobal(sizeof(Nodo<T>));
            nuevoNodo->dato = dato;
            nuevoNodo->siguiente = null;

            if (cima == null)
            {
                cima = nuevoNodo;
                fondo = nuevoNodo;
            }
            else
            {
                Nodo<T>* actual = cima;
                Nodo<T>* anterior = null;

                while (actual != null)
                {
                    if (actual->indice == indice)
                    {
                        if (anterior == null)
                        {
                            nuevoNodo->siguiente = actual;
                            cima = nuevoNodo;
                        }
                        else
                        {
                            anterior->siguiente = nuevoNodo;
                            nuevoNodo->siguiente = actual;
                        }

                        tamano++;
                        indexar();
                        break;
                    }

                    anterior = actual;
                    actual = actual->siguiente;
                }
            }
        }

        public unsafe void revolver()
        {
            Random random = new Random();
            Nodo<T>* actual = cima;
            Nodo<T>* auxiliar = null;
            T datoAuxiliar;
            int indiceAuxiliar;

            while (actual != null)
            {
                auxiliar = cima;

                // nos vamos a una posicion x
                for (int i = 0; i < random.Next(0, tamano); i++)
                {
                    auxiliar = auxiliar->siguiente;
                }

                // intercambiamos los datos
                datoAuxiliar = actual->dato;
                indiceAuxiliar = actual->indice;

                actual->dato = auxiliar->dato;
                actual->indice = auxiliar->indice;

                auxiliar->dato = datoAuxiliar;
                auxiliar->indice = indiceAuxiliar;

                // avanzar a a siguiente carta
                actual = actual->siguiente;
            }
            indexar();
        }
    }

    #endregion

    #region cola
    public unsafe class Cola<T> where T : class
    {
        private int Tamano;
        public int tamano
        {
            get { return Tamano; }
            set { Tamano = value; }
        }

        private unsafe Nodo<T>* Frente;
        public unsafe Nodo<T>* frente
        {
            get { return Frente; }
            set { Frente = value; }
        }

        private unsafe Nodo<T>* Final;
        public unsafe Nodo<T>* final
        {
            get { return Final; }
            set { Final = value; }
        }

        public unsafe Cola()
        {
            Tamano = 0;
            Frente = null;
            Final = null;
        }

        public unsafe void indexar()
        {
            Nodo<T>* actual = frente;
            int indice = 0;
            while (actual != null)
            {
                actual->indice = indice;
                indice++;
                actual = actual->siguiente;
            }
        }

        public unsafe void encolar(T dato)
        {
            Nodo<T>* nuevoNodo = (Nodo<T>*)Marshal.AllocHGlobal(sizeof(Nodo<T>));
            nuevoNodo->dato = dato;
            nuevoNodo->siguiente = null;

            if (frente == null)
            {
                frente = nuevoNodo;
                final = nuevoNodo;
            }
            else
            {
                final->siguiente = nuevoNodo;
                final = nuevoNodo;
            }

            tamano++;
            indexar();
        }

        public unsafe T desencolar()
        {
            if (frente == null)
            {
                return null;
            }

            Nodo<T>* nodoDesencolado = frente;
            frente = frente->siguiente;

            tamano--;
            indexar();

            return nodoDesencolado->dato;
        }

        public unsafe T obtenerFrente()
        {
            return frente->dato;
        }

        public unsafe T obtenerFinal()
        {
            return final->dato;
        }

        public unsafe T obtenerDatoPorIndice(int indice)
        {
            Nodo<T>* actual = frente;
            while (actual != null)
            {
                if (actual->indice == indice)
                {
                    return actual->dato;
                }
                actual = actual->siguiente;
            }
            return null;
        }

        public unsafe T extraerPorIndice(int indice)
        {
            Nodo<T>* actual = frente;
            Nodo<T>* anterior = null;

            while (actual != null)
            {
                if (actual->indice == indice)
                {
                    if (anterior == null)
                    {
                        frente = actual->siguiente;
                    }
                    else
                    {
                        anterior->siguiente = actual->siguiente;
                    }
                    tamano--;
                    return actual->dato;
                }
                anterior = actual;
                actual = actual->siguiente;
            }

            indexar();
            return null;
        }


        public unsafe T extraerPorDato(T dato)
        {
            Nodo<T>* actual = frente;
            Nodo<T>* anterior = null;

            while (actual != null)
            {
                if (actual->dato == dato)
                {
                    if (anterior == null)
                    {
                        frente = actual->siguiente;
                    }
                    else
                    {
                        anterior->siguiente = actual->siguiente;
                    }
                    tamano--;
                    return actual->dato;
                }

                anterior = actual;
                actual = actual->siguiente;
            }


            indexar();
            return null;
        }

        public unsafe class ListaDoble<T> where T : class
        {
            private unsafe NodoDoble<T>* Cabeza;
            public unsafe NodoDoble<T>* cabeza { get; set; }
            private unsafe NodoDoble<T>* Cola;
            public unsafe NodoDoble<T>* cola { get; set; }
            private int Tamano;



            public unsafe void eliminarPorDato(T dato)
            {
                NodoDoble<T>* actual = Cabeza;
                while (actual != null)
                {
                    if (actual->dato.Equals(dato))
                    {
                        if (actual->anterior != null)
                        {
                            actual->anterior->siguiente = actual->siguiente;
                        }
                        else
                        {
                            Cabeza = actual->siguiente;
                        }

                        if (actual->siguiente != null)
                        {
                            actual->siguiente->anterior = actual->anterior;
                        }
                        else
                        {
                            Cola = actual->anterior;
                        }

                        Tamano--;
                        return;
                    }
                    actual = actual->siguiente;
                }
            }


        }

    }
    #endregion
}