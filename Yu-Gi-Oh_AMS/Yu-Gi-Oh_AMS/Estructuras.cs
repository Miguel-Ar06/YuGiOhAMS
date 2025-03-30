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
    }

    internal unsafe class ListaSimple<T> where T : class
    {
        public Nodo<T>* cabeza { get; set; }
        public Nodo<T>* cola { get; set; }

        int tamano { get; set; }

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

        public T obtenerPorIndice(int indice)
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
}
