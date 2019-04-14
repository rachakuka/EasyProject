myapp.controller('programador-controller', function ($scope, programadorService) {
    loadProgramadores();
    $scope.DadosPessoais = false;
    $scope.InformacaoDeTrabalho = true;
    $scope.Conhecimentos = true;
    $scope.ConfirmarDados = true;
    $scope.ListarProgramador = false;
    $scope.Ionic = "1";
    $scope.Reactjs = "1";
    $scope.Reactnative = "1";
    $scope.Android = "1";
    $scope.IOS = "1";
    $scope.HTML = "1";
    $scope.CSS = "1";
    $scope.Bootstrap = "1";
    $scope.Jquery = "1";
    $scope.AngularJS = "1";
    function loadProgramadores() {
        var ProgramadorRecords = programadorService.getAllProgramadores();
        ProgramadorRecords.then(function (d) {
            $scope.Programadores = d.data;
        },
            function (ex) {
                if (ex.status === 500) {
                    showMessage("ERRO|Ocorreu um erro com o servidor da aplicação, por favor contactar o suporte");
                } else {
                    showMessage(ex.data.msg);
                }
            });
    }

    $scope.save = function () {
        if ($scope.Conhecimentos === false) {
            if ($scope.IDProgramador && $scope.IDProgramador > 0) {
                $scope.update();
            }
            else
            {
                var Programador = {
                    EMail: $scope.EMail,
                    Nome: $scope.Nome,
                    Skype: $scope.Skype,
                    Telefone: $scope.Telefone,
                    Linkedin: $scope.Linkedin,
                    Cidade: $scope.Cidade,
                    Estado: $scope.Estado,
                    DisponibilidadeTrabalho: $scope.DisponibilidadeTrabalho,
                    MelhorHorario: $scope.MelhorHorario,
                    Pretensao: $scope.Pretensao,
                    Conhecimento: {
                        Ionic: $scope.Ionic,
                        Reactjs: $scope.Reactjs,
                        Reactnative: $scope.Reactnative,
                        Android: $scope.Android,
                        IOS: $scope.IOS,
                        HTML: $scope.HTML,
                        CSS: $scope.CSS,
                        Bootstrap: $scope.Bootstrap,
                        Jquery: $scope.Jquery,
                        AngularJS: $scope.AngularJS,
                        Outro: $scope.Outro
                    }
                };
                var saverecords = programadorService.save(Programador);
                saverecords.then(function (d) {
                    if (showMessage(d.data.msg)) {
                        $scope.getForUpdate(d.data.retorno)
                        $scope.DadosPessoais = true;
                        $scope.InformacaoDeTrabalho = true;
                        $scope.Conhecimentos = true;
                        $scope.ConfirmarDados = false;
                    }
                },
                    function (ex) {
                        showMessage(ex.data.msg);
                    });
            }

        } else {
            if (!$scope.DadosPessoais) {
                $scope.DadosPessoais = true;
                $scope.InformacaoDeTrabalho = false;
                $scope.Conhecimentos = true;
            }
            else if (!$scope.InformacaoDeTrabalho) {
                $scope.DadosPessoais = true;
                $scope.InformacaoDeTrabalho = true;
                $scope.Conhecimentos = false;
            }
        }
    }

    function LimparTudo() {
        $scope.EMail = '';
        $scope.Nome = '';
        $scope.Skype = '';
        $scope.Telefone = '';
        $scope.Linkedin = '';
        $scope.Cidade = '';
        $scope.Estado = '';
        $scope.Conhecimento = '';
        $scope.DisponibilidadeTrabalho = '';
        $scope.MelhorHorario = '';
        $scope.Pretensao = '';
        $scope.Ionic = "1";
        $scope.Reactjs = "1";
        $scope.Reactnative = "1";
        $scope.Android = "1";
        $scope.IOS = "1";
        $scope.HTML = "1";
        $scope.CSS = "1";
        $scope.Bootstrap = "1";
        $scope.Jquery = "1";
        $scope.AngularJS = "1";
        $scope.Outro = '';
    }

    $scope.resetSave = function () {
        if ($scope.DadosPessoais === false) {
            LimparTudo();
        } else if ($scope.InformacaoDeTrabalho === false) {
            $scope.DadosPessoais = false
            $scope.InformacaoDeTrabalho = true;
            $scope.Conhecimentos = true;
        }
        else if ($scope.Conhecimentos === false) {
            $scope.InformacaoDeTrabalho = false;
            $scope.DadosPessoais = true
            $scope.Conhecimentos = true;
        } else {
            LimparTudo();
        }

    }

    $scope.editar = function () {
        $scope.DadosPessoais = false;
        $scope.InformacaoDeTrabalho = true;
        $scope.Conhecimentos = true;
        $scope.ConfirmarDados = true;
    }

    $scope.update = function () {
         var Programador = {
            IDProgramador: $scope.IDProgramador,
            EMail: $scope.EMail,
            Nome: $scope.Nome,
            Skype: $scope.Skype,
            Telefone: $scope.Telefone,
            Linkedin: $scope.Linkedin,
            Cidade: $scope.Cidade,
            Estado: $scope.Estado,
            Conhecimento: $scope.Conhecimento,
            DisponibilidadeTrabalho: $scope.DisponibilidadeTrabalho,
            MelhorHorario: $scope.MelhorHorario,
            Pretensao: $scope.Pretensao,
            Conhecimento: {
                IDProgramador: $scope.IDProgramador,
                Ionic: $scope.Ionic,
                Reactjs: $scope.Reactjs,
                Reactnative: $scope.Reactnative,
                Android: $scope.Android,
                IOS: $scope.IOS,
                HTML: $scope.HTML,
                CSS: $scope.CSS,
                Bootstrap: $scope.Bootstrap,
                Jquery: $scope.Jquery,
                AngularJS: $scope.AngularJS,
                Outro: $scope.Outro
            }
        };
        var updaterecords = programadorService.update(Programador);
        updaterecords.then(function (d) {
            if (showMessage(d.data.msg)) {
                loadProgramadores();
                $scope.DadosPessoais = true;
                $scope.InformacaoDeTrabalho = true;
                $scope.Conhecimentos = true;
                $scope.ConfirmarDados = false;
                $scope.ListarProgramador = false;
            }
        },
            function (ex) {
                showMessage(ex.data.msg);
            });
    }

    $scope.ListaProfissional = function () {
        $location.path("/Programador/Listar");
    }

    $scope.resetUpdate = function () {
        $scope.IDProgramador = '';
        $scope.EMail = '';
        $scope.Nome = '';
        $scope.Skype = '';
        $scope.Telefone = '';
        $scope.Linkedin = '';
        $scope.Cidade = '';
        $scope.Estado = '';
        $scope.Conhecimento = '';
        $scope.DisponibilidadeTrabalho = '';
        $scope.MelhorHorario = '';
        $scope.Pretensao = '';
        $scope.Ionic = "1";
        $scope.Reactjs = "1";
        $scope.Reactnative = "1";
        $scope.Android = "1";
        $scope.IOS = "1";
        $scope.HTML = "1";
        $scope.CSS = "1";
        $scope.Bootstrap = "1";
        $scope.Jquery = "1";
        $scope.AngularJS = "1";
        $scope.Outro = '';
    }

    $scope.delete = function (prog) {
        let nomeProg = "";
        var IDProgramador = "";
        if (typeof prog === "object") {
            nomeProg = prog.Nome;
            IDProgramador = prog.IDProgramador;
        }
        else {
            nomeProg = $scope.Nome;
            IDProgramador = prog;
        }

        alertify.confirm('Remover registro', 'Deletar programador: ' + nomeProg + " ?", function () {
            var deleterecord = programadorService.delete(IDProgramador);
            deleterecord.then(function (d) {
                if (showMessage(d.data.msg)) {
                    $scope.resetUpdate();
                    loadProgramadores();
                    $scope.DadosPessoais = false;
                    $scope.InformacaoDeTrabalho = true;
                    $scope.Conhecimentos = true;
                    $scope.ConfirmarDados = true;
                }
            },
                function (ex) {
                    if (ex.status === 500) {
                        showMessage("ERRO|Ocorreu um erro com o servidor da aplicação, por favor contactar o suporte");
                    } else {
                        showMessage(ex.data.msg);
                    }
                });
            }
        , function () { });
    }

    $scope.getForUpdate = function (Programador) {
        $scope.ListarProgramador = true;
        $scope.IDProgramador = Programador.IDProgramador;
        $scope.EMail = Programador.EMail;
        $scope.Nome = Programador.Nome;
        $scope.Pretensao = Programador.Pretensao;
        $scope.Skype = Programador.Skype;
        $scope.Telefone = Programador.Telefone;
        $scope.Linkedin = Programador.Linkedin;
        $scope.Cidade = Programador.Cidade;
        $scope.Estado = Programador.Estado;
        $scope.Conhecimento = Programador.Conhecimento;
        $scope.DisponibilidadeTrabalho = Programador.DisponibilidadeTrabalho;
        $scope.MelhorHorario = Programador.MelhorHorario;
        if (Programador.Conhecimento !== null) {
            
            $scope.Ionic = Programador.Conhecimento.Ionic !== null ? Programador.Conhecimento.Ionic.toString() : "1";
            $scope.Reactjs = Programador.Conhecimento.Reactjs !== null ? Programador.Conhecimento.Reactjs.toString() : "1";
            $scope.Reactnative = Programador.Conhecimento.Reactnative !== null ? Programador.Conhecimento.Reactnative.toString() : "1";
            $scope.Android = Programador.Conhecimento.Android !== null ? Programador.Conhecimento.Android.toString() : "1";
            $scope.IOS = Programador.Conhecimento.IOS !== null ? Programador.Conhecimento.IOS.toString() : "1";
            $scope.HTML = Programador.Conhecimento.HTML !== null ? Programador.Conhecimento.HTML.toString() : "1";
            $scope.CSS = Programador.Conhecimento.CSS !== null ? Programador.Conhecimento.CSS.toString() : "1";
            $scope.Bootstrap = Programador.Conhecimento.Bootstrap !== null ? Programador.Conhecimento.Bootstrap.toString() : "1";
            $scope.Jquery = Programador.Conhecimento.Jquery !== null ? Programador.Conhecimento.Jquery.toString() : "1";
            $scope.AngularJS = Programador.Conhecimento.AngularJS !== null ? Programador.Conhecimento.AngularJS.toString() : "1";
            $scope.Outro = Programador.Conhecimento.Outro;
        }
    }

    $scope.getForUpdateEdit = function (Programador) {
        $scope.ListarProgramador = true;
        $scope.EditIDProgramador = Programador.IDProgramador;
        $scope.EditEMail = Programador.EMail;
        $scope.EditNome = Programador.Nome;
        $scope.EditPretensao = Programador.Pretensao;
        $scope.EditSkype = Programador.Skype;
        $scope.EditTelefone = Programador.Telefone;
        $scope.EditLinkedin = Programador.Linkedin;
        $scope.EditCidade = Programador.Cidade;
        $scope.EditEstado = Programador.Estado;
        $scope.EditConhecimento = Programador.Conhecimento;
        $scope.EditDisponibilidadeTrabalho = Programador.DisponibilidadeTrabalho;
        $scope.EditMelhorHorario = Programador.MelhorHorario;
        if (Programador.Conhecimento !== null) {

            $scope.EditIonic = Programador.Conhecimento.Ionic !== null ? Programador.Conhecimento.Ionic.toString() : "1";
            $scope.EditReactjs = Programador.Conhecimento.Reactjs !== null ? Programador.Conhecimento.Reactjs.toString() : "1";
            $scope.EditReactnative = Programador.Conhecimento.Reactnative !== null ? Programador.Conhecimento.Reactnative.toString() : "1";
            $scope.EditAndroid = Programador.Conhecimento.Android !== null ? Programador.Conhecimento.Android.toString() : "1";
            $scope.EditIOS = Programador.Conhecimento.IOS !== null ? Programador.Conhecimento.IOS.toString() : "1";
            $scope.EditHTML = Programador.Conhecimento.HTML !== null ? Programador.Conhecimento.HTML.toString() : "1";
            $scope.EditCSS = Programador.Conhecimento.CSS !== null ? Programador.Conhecimento.CSS.toString() : "1";
            $scope.EditBootstrap = Programador.Conhecimento.Bootstrap !== null ? Programador.Conhecimento.Bootstrap.toString() : "1";
            $scope.EditJquery = Programador.Conhecimento.Jquery !== null ? Programador.Conhecimento.Jquery.toString() : "1";
            $scope.EditAngularJS = Programador.Conhecimento.AngularJS !== null ? Programador.Conhecimento.AngularJS.toString() : "1";
            $scope.EditOutro = Programador.Conhecimento.Outro;
        }
    }

    $scope.updateEdit = function () {
        var Programador = {
            IDProgramador: $scope.EditIDProgramador,
            EMail: $scope.EditEMail,
            Nome: $scope.EditNome,
            Skype: $scope.EditSkype,
            Telefone: $scope.EditTelefone,
            Linkedin: $scope.EditLinkedin,
            Cidade: $scope.EditCidade,
            Estado: $scope.EditEstado,
            Conhecimento: $scope.EditConhecimento,
            DisponibilidadeTrabalho: $scope.EditDisponibilidadeTrabalho,
            MelhorHorario: $scope.EditMelhorHorario,
            Pretensao: $scope.EditPretensao,
            Conhecimento: {
                IDProgramador: $scope.EditIDProgramador,
                Ionic: $scope.EditIonic,
                Reactjs: $scope.EditReactjs,
                Reactnative: $scope.EditReactnative,
                Android: $scope.EditAndroid,
                IOS: $scope.EditIOS,
                HTML: $scope.EditHTML,
                CSS: $scope.EditCSS,
                Bootstrap: $scope.EditBootstrap,
                Jquery: $scope.EditJquery,
                AngularJS: $scope.EditAngularJS,
                Outro: $scope.EditOutro
            }
        };
        var updaterecords = programadorService.update(Programador);
        updaterecords.then(function (d) {
            if (showMessage(d.data.msg)) {
                loadProgramadores();
                $scope.DadosPessoais = true;
                $scope.InformacaoDeTrabalho = true;
                $scope.Conhecimentos = true;
                $scope.ConfirmarDados = false;
                $scope.ListarProgramador = false;
            }
        },
            function (ex) {
                showMessage(ex.data.msg);
            });
    }

    $scope.getForDelete = function (idProgramador) {
        $scope.IDProgramador = idProgramador;
    }

    $scope.orderByMe = function (x) {
        $scope.myOrderBy = x;
    }
});