﻿class IndexEstudiante{
    constructor(data){
        data = data ||{};
        var self = this;

        //#region Propiedades principales
        self.Estudiantes = ko.observableArray(data.Estudiantes ? data.Estudiantes.map(x=> new EstudianteVM(x)) : []);

        self.OperadoraTelefonos = data.OperadoraTelefonos || [];
        
        self.CargandoPeticion = ko.observable(false);

        self.PeticionEnCurso = ko.observable(null);

        self.EstudianteM = ko.observable(new EstudianteVM());

        self.DetalleTelefono = ko.observable(new DetalleEstudianteTelefono());
        //#endregion

        //#region Funciones Publicas
        self.ResfrescarEstudiantes = function(){
            GetEstudiantes();
        };

        self.ShowModal = (datos, action)=>{
            console.log(datos)
            console.log(action)
        };

        self.AddTelefono = (dato)=>{
            var detalle = ko.toJS(dato);
            var operadora = self.OperadoraTelefonos.find(x=> x.Id == detalle.OperadoraTelefonoId);

            self.EstudianteM().DetalleEstudianteTelefonos.push(new DetalleEstudianteTelefono({ ...detalle, DescripcionOperadora: operadora?.Descripcion || "" }));
            self.DetalleTelefono(new DetalleEstudianteTelefono());
        };

        self.RemoveTelefono = (dato)=>{
            self.EstudianteM().DetalleEstudianteTelefonos.remove(dato);
        };
        //#endregion

        //#region Funciones privadas
        function GetEstudiantes() {
            let rootUrl = $("#root-url-input").val();
            let url = rootUrl + "Estudiante/GetEstudiantes";
            
            return $.ajax({
                url: url,
                method: "GET",
                //data: { nombreFacultad: self.FiltroNombreFacultad() },
                dataType: "json",
                beforeSend: (jqXHR, settings) => {  // Peticion en curso
                    if(self.PeticionEnCurso()){
                        self.PeticionEnCurso().abort();
                    }
                    self.CargandoPeticion(true);
                    self.PeticionEnCurso(jqXHR);
                },
                success: (respuesta) => {
                    console.log(respuesta);
                    if(respuesta.Success){
                        self.Estudiantes(respuesta.Record ? respuesta.Record.map(x=> new EstudianteVM(x)) : []);
                    }else{
                        alert(respuesta.Message);
                    }
                },
                complete: (jqXHR, textStatus) => {
                    self.CargandoPeticion(false);
                    self.PeticionEnCurso(null);
                },
                error: (jqXHR, textStatus, errorThrown) => {
                    if(textStatus != "abort"){
                        alert("Error: Error De Servidor");
                    }
                }
            });
        }

        //#endregion
    }
}


var data = JSON.parse($("#JsonData").val());
ko.applyBindings(new IndexEstudiante(data));