(function(){
    'use strict';
        angular.module('mwa').config(function($routeProvider) {
            $routeProvider
            .when('/',{
                
                controller:'HomeController',
                controllerAs:'vm',
                templateUrl:'pages/home/index.html'
            })
            .when('/login',{
                
                controller:'LoginController',
                controllerAs:'vm',
                templateUrl:'pages/account/login.html'
            });
            // .when('/logout',{
                
            //     controller:'LogoutController',
            //     controllerAs:'vm',
            //     templateUrl:'pages/account/login.html'
            // })
            // .when('/usuarios',{
                
            //     controller:'UsuarioController',
            //     controllerAs:'vm',
            //     templateUrl:'pages/usuario/index.html'
            // })
            // .when('/categorias',{
                
            //     controller:'CategoriaListaController',
            //     controllerAs:'vm',
            //     templateUrl:'pages/categoria/index.html'
            // })
            // .when('/categorias/editar/:id',{
                
            //     controller:'CategoriaEditarController',
            //     controllerAs:'vm',
            //     templateUrl:'pages/categorias/editar.html'
            // });
           
        })
    
})();