import React, { useState } from "react";
import { Book } from "../../components/Book";
import "./Home.css";

export const Home = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [books, setBooks] = useState([]);
  const safeSetSearch = (e) => {
    const input = e.target.value;
    setSearchTerm(input);
  };

  const onSubmit = async (e) => {
    e.preventDefault();
    const response = await fetch(`/api/booksearch?q=${searchTerm}`);
    const booksJson = await response.json();
    setBooks(booksJson);
  };

  return (
    <div>
      <h1>Fifth Dimension</h1>
      <h3>Google Books Search</h3>

      <form className="input-group searchBar" onSubmit={onSubmit}>
        <input
          type="text"
          className="form-control"
          placeholder="Enter a term..."
          value={searchTerm}
          onChange={safeSetSearch}
        />
        <div className="input-group-append">
          <button
            className="btn btn-primary"
            type="submit"
            disabled={!searchTerm.trim()}
          >
            Search
          </button>
        </div>
      </form>

      {!!books.length && (
        <div className="results">
          <div>
            {books.map((book) => (
              <Book key={book.id} book={book} />
            ))}
          </div>
        </div>
      )}
    </div>
  );
};
