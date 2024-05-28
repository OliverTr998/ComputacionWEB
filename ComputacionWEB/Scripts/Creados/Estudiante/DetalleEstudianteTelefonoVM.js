class DetalleEstudianteTelefono{
    constructor(data){
        data = data || {};
        var self = this;
        
        self.Id = ko.observable(data.Id || "");
        self.Numero = ko.observable(data.Numero || "");
        self.EstudianteId = ko.observable(data.EstudianteId || "");
        self.OperadoraTelefonoId = ko.observable(data.OperadoraTelefonoId || "");

        //propiedades extras 
        self.DescripcionOperadora = ko.observable(data.DescripcionOperadora || "");
    }
}