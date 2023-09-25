import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'; // Importa FormBuilder y Validators
import { MovieService } from '../../services/movie.service';
import { Movie } from '../../models/movie.model';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css'],
})
export class MovieListComponent implements OnInit {
  movies: Movie[] = [];
  selectedMovie: Movie | null = null;
  newMovie: Movie = {
    id: 0,
    title: '',
    director: '',
    gender: '',
    description: '',
  };
  isEditing: boolean = false; 
  movieForm: FormGroup;

  constructor(private movieService: MovieService, private fb: FormBuilder) {
    this.movieForm = this.fb.group({
      title: ['', Validators.required],
      director: ['', Validators.required],
      gender: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.loadMovies();
    this.clearSelection();
  }

  loadMovies(): void {
    this.movieService.getMovies().subscribe((movies) => {
      this.movies = movies;
    });
  }

  selectMovie(movie: Movie): void {
    this.selectedMovie = { ...movie };
  }

  clearSelection(): void {
    this.selectedMovie = null;
    this.isEditing = false;
    this.movieForm.reset(); 
  }

  createMovie(): void {
    if (this.movieForm.valid) {
      const movie = this.movieForm.value as Movie;
      this.movieService.createMovie(movie).subscribe((response) => {
        console.log('Movie created:', response);
        this.loadMovies();
        this.clearSelection();
      });
    } else {
      this.movieForm.markAllAsTouched();
    }
  }

  editMovie(movie: Movie): void {
    this.isEditing = true; 
    this.selectMovie(movie); 
    this.movieForm.patchValue({
      title: movie.title,
      director: movie.director,
      gender: movie.gender,
      description: movie.description,
    });
  }

  updateMovie(): void {
    if (this.selectedMovie && this.movieForm.valid) {
      const movie = this.movieForm.value as Movie;
      this.movieService.updateMovie(this.selectedMovie.id, movie).subscribe(() => {
        this.loadMovies();
        this.clearSelection();
      });
    } else {
      this.movieForm.markAllAsTouched();
    }
  }

  confirmDelete(movie: Movie): void {
    const confirmation = window.confirm(
      `¿Estás seguro de que deseas eliminar la película "${movie.title}"?`
    );

    if (confirmation) {
      this.deleteMovie(movie.id);
    }
  }

  deleteMovie(id: number): void {
    this.movieService.deleteMovie(id).subscribe(() => {
      this.loadMovies();
      this.clearSelection();
    });
  }
}
