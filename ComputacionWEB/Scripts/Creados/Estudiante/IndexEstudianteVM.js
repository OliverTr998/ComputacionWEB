class IndexEstudiante{
    constructor(data){
        data = data ||{};
        var self = this;

        //#region Propiedades principales
        self.Estudiantes = ko.observableArray(data.Estudiantes ? data.Estudiantes.map(x=> new EstudianteVM(x)) : []);

        self.EstudiantesProcedure = ko.observableArray(data.EstudiantesProcedure || []);

        self.OperadoraTelefonos = data.OperadoraTelefonos || [];
        
        self.CargandoPeticion = ko.observable(false);

        self.CargandoPeticionCRUD = ko.observable(false);

        self.PeticionEnCurso = ko.observable(null);

        self.Accion = ko.observable("");

        self.EstudianteM = ko.observable(new EstudianteVM());

        self.FiltrosEstudiante = ko.observable(new FiltrosEstudianteVM());

        self.DetalleTelefono = ko.observable(new DetalleEstudianteTelefono());
        //#endregion

        //#region Funciones Publicas
        self.ResfrescarEstudiantes = function(){
            GetEstudiantes();
        };

        self.ShowModal = (datos, action)=>{
            console.log(datos)
            console.log(action)
            self.Accion(action);
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

        self.CRUD = ()=>{
            let est = ko.toJS(self.EstudianteM);
            console.log(est);
            CRUDEstudiante(est);
        };

        self.GetFilterEstudiante = ()=>{
            GetEstudiantesFilter();
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

        function GetEstudiantesFilter() {
            let rootUrl = $("#root-url-input").val();
            let url = rootUrl + "Estudiante/GetEstudiantesFilter";
            
            return $.ajax({
                url: url,
                method: "POST",
                data: { viewModel: ko.toJS(self.FiltrosEstudiante) },
                dataType: "json",
                beforeSend: (jqXHR, settings) => {  // Peticion en curso
                    if(self.PeticionEnCurso()){
                        self.PeticionEnCurso().abort();
                    }
                    self.CargandoPeticion(true);
                    self.PeticionEnCurso(jqXHR);
                },
                success: (respuesta) => {
                    if(respuesta.Success){
                        self.EstudiantesProcedure(respuesta.Record || []);
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

        function CRUDEstudiante(estudiante){
            let rootUrl = $("#root-url-input").val();
            let url = rootUrl + "Estudiante/" + self.Accion();
            let $form = document.getElementById("CRUDForm");
            
            if($($form).valid()){
                return $.ajax({
                    url: url,
                    method: "POST",
                    data: { estudiante: estudiante },
                    dataType: "json",
                    beforeSend: (jqXHR, settings) => {  // Peticion en curso
                        if(self.PeticionEnCurso()){
                            self.PeticionEnCurso().abort();
                        }
                        self.CargandoPeticionCRUD(true);
                        self.PeticionEnCurso(jqXHR);
                    },
                    success: (respuesta) => {
                        if(respuesta.Success){
                            self.EstudianteM(new EstudianteVM());
                            GetEstudiantes();
                            alert(respuesta.Message);
                        }else{
                            alert(respuesta.Message);
                        }
                    },
                    complete: (jqXHR, textStatus) => {
                        self.CargandoPeticionCRUD(false);
                        self.PeticionEnCurso(null);
                    },
                    error: (jqXHR, textStatus, errorThrown) => {
                        if(textStatus != "abort"){
                            alert("Error: Error De Servidor");
                        }
                    }
                });
            }
            
        }
        //#endregion
    }
}


var data = JSON.parse($("#JsonData").val());
ko.applyBindings(new IndexEstudiante(data));