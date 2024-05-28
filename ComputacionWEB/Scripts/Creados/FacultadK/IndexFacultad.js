class FacultadVM {
    constructor(data) {
        data = data || {};

        self.Id = ko.observable(data.Id || "");
        self.Codigo = ko.observable(data.Codigo || "");
        self.Descripcion = ko.observable(data.Descripcion || "");
    }
}

class IndexFacultad {
    constructor(data) {
        data = data || {};
        var self = this;

        self.Titulo = ko.observable("Facultades");

        self.CargandoPeticion = ko.observable(false);

        self.FiltroNombreFacultad = ko.observable("");

        self.RegistroSeleccionado = ko.observable(new FacultadVM());

        self.Facultades = ko.observableArray(data.Facultades || []);

        self.GetFacultadesAPI = () => {
            GetFacultadesAPI();
        };

        self.ShowModal = (data) => {
            self.RegistroSeleccionado(new FacultadVM(ko.toJS(data)));
        };

        function GetFacultadesAPI() {
            let rootUrl = $("#root-url-input").val();
            let url = rootUrl + "FacultadK/GetFacultades";
            
            return $.ajax({
                url: url,
                method: "GET",
                data: { nombreFacultad: self.FiltroNombreFacultad() },
                dataType: "json",
                beforeSend: (jqXHR, settings) => {  // Peticion en curso
                    self.CargandoPeticion(true);
                },
                success: (respuesta) => {
                    self.Facultades(respuesta);
                },
                complete: (jqXHR, textStatus) => {
                    self.CargandoPeticion(false);
                },
                error: (jqXHR, textStatus, errorThrown) => {
                    alert("Error: Error De Servidor");
                }
            });
        }
    }
}

var data = JSON.parse($("#JsonData").val());

ko.applyBindings(new IndexFacultad(data));