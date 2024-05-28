class DetalleEstudianteTelefono{
    constructor(data){
        data = data || {};
        var self = this;
        
        self.Id = ko.observable(data.Id || 0);
        self.Numero = ko.observable(data.Numero || "");
        self.EstudianteId = ko.observable(data.EstudianteId || 0);
        self.OperadoraTelefonoId = ko.observable(data.OperadoraTelefonoId || "");

        //propiedades extras 
        self.DescripcionOperadora = ko.observable(data.DescripcionOperadora || "");
    }
}