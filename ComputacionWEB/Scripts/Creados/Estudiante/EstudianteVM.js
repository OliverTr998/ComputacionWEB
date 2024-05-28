class EstudianteVM{
    constructor(data){
        data = data || {};
        var self = this;

        self.Id = ko.observable(data.Id || 0);
        self.Carnet = ko.observable(data.Carnet || "");
        self.Nombre = ko.observable(data.Nombre || "");
        self.Apellido = ko.observable(data.Apellido || "");
        self.Edad = ko.observable(data.Edad || "");
        self.CarreraId = ko.observable(data.CarreraId || 0);

        //Propiedades Extras
        self.DescripcionCarrera = ko.observable(data.DescripcionCarrera || "");
        self.DetalleEstudianteTelefonos = ko.observableArray(data.DetalleEstudianteTelefonos ? data.DetalleEstudianteTelefonos.map(x=> new DetalleEstudianteTelefono(x)) : []);

        self.NumerosTelofonos = ko.computed(()=>{
            if(self.DetalleEstudianteTelefonos().length > 0){
                let numeros = ko.toJS(self.DetalleEstudianteTelefonos).map(x => (x.DescripcionOperadora  + ": " + x.Numero ) ).join(' | ');
                return numeros;
            }

            return "NINGUNO";
        });
        
    }
} 