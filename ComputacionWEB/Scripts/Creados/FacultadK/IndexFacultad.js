class IndexFacultad {
    constructor(data) {
        data = data || {};
        var self = this;

        self.Titulo = ko.observable("Facultades");

        self.Facultades = ko.observableArray(data.Facultades || []);

        self.GetFacultadesAPI = ()=>{
            GetFacultadesAPI();
        };

        function GetFacultadesAPI() {
            let input = $("#root-url-input");
            let value = input.val();

            let url = value + "FacultadK/GetFacultades"

            return $.ajax({
                url: url,
                method: "GET",
                data: {},
                dataType: "json",
                beforeSend: (jqXHR, settings) => {  // Peticion en curso
                    console.log("beforeSend");
                    console.log(jqXHR);
                    console.log(settings);
                },
                success: (respuesta)=>{
                    console.log("Respuesta");
                    console.log(respuesta);

                },
                complete: (jqXHR, textStatus)=>{
                    console.log("complete");
                    console.log(jqXHR);
                    console.log(textStatus);
                },
                error: (jqXHR, textStatus, errorThrown)=>{
                    console.log("Error");
                    console.log(jqXHR);
                    console.log(textStatus);
                    console.log(errorThrown);
                }
            });
        }
    }
}

var data = JSON.parse($("#JsonData").val());

ko.applyBindings(new IndexFacultad(data));