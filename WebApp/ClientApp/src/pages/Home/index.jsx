import React, { useState } from "react";
import "./Home.css";

export const Home = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const safeSetSearch = (e) => {
    const input = e.target.value;
    setSearchTerm(input);
  };

  return (
    <div>
      <h1>Fifth Dimension</h1>
      <h3>Google Books Search</h3>

      <form className="input-group searchBar">
        <input
          type="text"
          class="form-control"
          placeholder="Enter a term..."
          value={searchTerm}
          onChange={safeSetSearch}
        />
        <div className="input-group-append">
          <button
            class="btn btn-primary"
            type="button"
            disabled={!searchTerm.trim()}
          >
            Search
          </button>
        </div>
      </form>
    </div>
  );
};
