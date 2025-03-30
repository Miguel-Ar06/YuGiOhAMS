using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Yu_Gi_Oh_AMS
{
    #region Lista Simple y Nodo

    internal unsafe class Nodo<T> where T : class
    {
        public T dato { get; set; }
        public Nodo<T>* siguiente { get; set; }
        public int indice { get; set; }

        public Nodo(T dato)
        {
            this.dato = dato;
            this.indice = 0;
            this.siguiente = null;
        }
    }

    internal unsafe class ListaSimple<T> where T : class
    {
        public Nodo<T>* cabeza { get; set; }
        public Nodo<T>* cola { get; set; }

        public int tamano { get; set; }

        public ListaSimple()
        {
            cabeza = null;
            cola = null;
        }

        public void agregar(T dato)
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

        public void eliminarPorDato(T dato)
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

        public void eliminarPorIndice(int indice)
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

        public void indexar()
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

        public T obtenerDatoPorIndice(int indice)
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

        public int obtenerIndicePorDato(T dato)
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

    internal unsafe class NodoDoble<T> where T : class
    {
        public T dato { get; set; }
        public NodoDoble<T>* anterior { get; set; }
        public NodoDoble<T>* siguiente { get; set; }
        public int indice { get; set; }

        public NodoDoble(T dato)
        {
            this.dato = dato;
            this.anterior = null;
            this.siguiente = null;
            indice = 0;
        }
    }

    internal unsafe class ListaDoble<T> where T : class
    {
        public NodoDoble<T>* cabeza { get; set; }
        public NodoDoble<T>* cola { get; set; }
        public int tamano { get; set; }
        public ListaDoble()
        {
            cabeza = null;
            cola = null;
        }
        public void agregar(T dato)
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
        public void agregarEnPosicion(T dato, int posicion)
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
        public void eliminarPorDato(T dato)
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
                indexar();
            }
        }
        public void eliminarPorIndice(int indice)
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
        public void indexar()
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
        public T obtenerDatoPorIndice(int indice)
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
        public int obtenerIndicePorDato(T dato)
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
        public void revolver()
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
    internal unsafe class Pila<T> where T : class
    {
        public Nodo<T>* cima { get; set; }
        public Nodo<T>* fondo { get; set; }
        public int tamano { get; set; }
        public Pila()
        {
            cima = null;
            fondo = null;
            tamano = 0;
        }

        public void indexar()
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

        public void apilar(T dato)
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

        public T desapilar()
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

        public T obtenerCima()
        {
            return cima->dato;
        }

        public T obtenerFondo()
        {
            return fondo->dato;
        }

        public T obtenerDatoPorIndice(int indice)
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

        public T extraer(int indice)
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

        public void insertarEnPosicion(T dato, int indice)
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

        public void revolver()
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
    internal unsafe class Cola<T> where T : class
    {
        public int tamano { get; set; }
        public Nodo<T>* frente { get; set; }
        public Nodo<T>* final { get; set; }

        public Cola()
        {
            tamano = 0;
            frente = null;
            final = null;
        }

        public void indexar()
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

        public void encolar(T dato)
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

        public T desencolar()
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

        public T obtenerFrente()
        {
            return frente->dato;
        }

        public T obtenerFinal()
        {
            return final->dato;
        }

        public T obtenerDatoPorIndice(int indice)
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

        public T extraerPorIndice(int indice)
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

        public T extraerPorDato(T dato)
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
    }
    #endregion
}