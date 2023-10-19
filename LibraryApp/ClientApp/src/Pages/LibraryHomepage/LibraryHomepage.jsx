

const LibraryHomepage = () => {
    useEffect(async () => {
        await fetchBooks();
    }, [])
    
    const fetchBooks = async() => {
        let booksJson = await fetch('');
        let books = booksJson.Json();
        console.log(books);
    }
    
    
    return (
        <></>
    )
    
}