import React from "react";
import "./Book.css";

export const BookField = ({ title, value, defaultValue, bold }) => {
  if ((!value || !value.trim()) && !defaultValue) {
    return null;
  }

  title = title ? `${title} :` : "";

  return (
    <div className={bold ? "bold" : ""}>
      {title} {value || defaultValue}
    </div>
  );
};
