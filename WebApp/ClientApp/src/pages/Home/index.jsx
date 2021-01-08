import React, { useState } from "react";
import "./Home.css";

export const Home = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const safeSetSearch = (e) => {
    const input = e.target.value;
    setSearchTerm(input);
  };

  const onSubmit = async (e) => {
    e.preventDefault();
    console.log("api");
    await fetch(`/api/booksearch?q=${searchTerm}`);
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
    </div>
  );
};
