import React from "react";
import { createRoot } from "react-dom/client";
import AppRouter from "./router";
import "./index.css";
import "bootstrap/dist/css/bootstrap.min.css";


createRoot(document.getElementById("root")).render(
    <React.StrictMode>
        <AppRouter />
    </React.StrictMode>
);
