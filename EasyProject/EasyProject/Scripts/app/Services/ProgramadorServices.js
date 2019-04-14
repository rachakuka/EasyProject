myapp.service('programadorService', function ($http) {
    
    this.getAllProgramadores = function () {
        return $http.get("/Programador/GetProgramadores");
    }
    

    this.save = function (Programador) {
        var request = $http({
            method: 'post',
            url: '/Programador/Insert',
            data: Programador
        });
        return request;
    }

    this.update = function (Programador) {
        var updaterequest = $http({
            method: 'post',
            url: '/Programador/Update',
            data: Programador
        });
        return updaterequest;
    }

    this.delete = function (idProgramador) {
        return $http.post("/Programador/Delete/" + idProgramador);
    }

});