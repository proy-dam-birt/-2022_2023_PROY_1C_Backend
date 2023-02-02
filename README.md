# DAM
El objeto de este proyecto es el de la descarga y actualizacion programada de datos desde APIs, su procesamiento y guardado en Base de datos,
de forma tal que, mediante la generacion de endpoints, puedan ser utilizados por una aplicacion de frontend para los CRUD sobre la/s base de datos, 
frontend que estara en otro proyecto, con el que se vinculara mas adelante.

Este proyecto comprende en una primera fase la conformacion de la estructura inicial, en capas, aplicando el concepto "Arquitectura limpia", 
de forma que se pueda producir un optimo encapsulamiento funcional.

Se estructura el proyecto, de forma inicial en 2 carpetas:
Ficheros .txt de Informacion contiene diversos ficheros con explicaciones sobre como se llego a este punto en el dia de hoy que se ha recuperado el proyecto en Github, Nomenclatura a seguir, Errores y soluciones, Webgrafia, y otros.

La segunda carpeta, DAM.Proyecto, contiene varios proyectos y una solucion.
5 proyectos, siendo cada uno una capa o parte funcional de una capa: 
                            Domain: las entidades (abstracciones). 
                            Configuration: datos necesarios para la conexion con BD, Trabajos, Apis, etc. 
                            DAL o Data Access Layer: Esta capa media entre Domain y lo exterior a la solucion: UI, BD, APi, etc.
                                                     Contiene los Repositorios, Unidades de trabajo, el contexto, y los proveedores de Servicios
                            SL: Es la capa que realiza los trabajos y servicios.
                            DAM.Proyecto que es la capa mas exterior, desde conde comienza la solucion.
                                Contiene el Programador de trabajos y la definicion de los mismos.
    
 
