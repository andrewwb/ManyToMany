namespace ManyToMany.Controllers {

    export class HomeController {
        public movies;
        public actors;
        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService) {
            $http.get('api/movies').then((res) => {
                this.movies = res.data;
            });

            $http.get('api/actors').then((res) => {
                this.actors = res.data
            });
        }

        public addMovie(id, movie) {
            this.$http.post(`api/movies/${id}`, movie).then((res) => {
                console.log(res);
                this.$state.reload();
            });
        }
    }



    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
