# 🛠️🌟 Primer entrega de proyecto SGE para la materia Seminario de Lenguajes (.NET) de la Facultad de Informatica UNLP. 
 **Este proyecto fue realizado con compañeros de la cursada**  
   
📌**En esta primer entrega: Hacemos todo por consola y persistimos los datos en archivos.**  
**🛠️Segunda entrega: Vamos a usar Blazor para proporcionar una interfaz de usuario y SQLite para la persistencia de datos**  
**En la primer entrega del proyecto, aplicamos :** 
  
   🟣 Arquitectura Limpia  
   🟣 Interfaces  
   🟣 Inyeccion de Dependencias  
   🟣 Excepciones   

   🟡 **Validaciones:**  
    - Se encarga de controlar el acceso de los datos, cada entidad que quiera ser agregada, debe cumplir con una serie de criterios.    
   
   🟡 **Servicios:**  
     - Servicio de cambio automatico: Proporciona un cambio automatico de estado en los Expedientes.  
     - Servicio de Autorizacion: Controla que el usuario que quiera realizar alguna operacion, tenga permiso.  
     (momentaneamente solo el usuario con id = 1 es el unico que tiene permisos)
   

