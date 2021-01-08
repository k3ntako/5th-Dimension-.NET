import React from "react";
import "./Book.css";
import { BookField } from "./BookField";

export const Book = ({ book }) => {
  const authors = book.authors && book.authors.join(", ");

  return (
    <div className="book">
      <BookField title="" value={book.title} defaultValue="[No Title]" bold />
      <BookField title="Authors" value={authors} />
      <BookField title="Publisher" value={book.publisher} />
      <BookField title="Publish Date" value={book.publishedDate} />
    </div>
  );
};
