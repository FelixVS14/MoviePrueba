export class Movie {
    id: number;
    title: string;
    director: string;
    gender: string;
    description: string;
  
    constructor(
      id: number,
      title: string,
      director: string,
      gender: string,
      description: string
    ) {
      this.id = id;
      this.title = title;
      this.director = director;
      this.gender = gender;
      this.description = description;
    }
  }
  