type Song = {
    author: string,
    name: string,
    year: number,
    rating: number,
}
const data: Song[] = [
    {author: 'Alex', name: '123', year: 2020, rating: 100},
    {author: 'Aria', name: 'Chimera', year: 2001, rating: 100},
    {author: 'Alex', name: 'asdfgh', year: 1991, rating: 10},
    {author: 'Bob', name: 'QWERTY', year: 2024, rating: 85}
];
let unique = [...new Set(data.map(item => item.author))];
console.log(unique) 