import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";


function App() {
    const [courses, setCourses] = useState([]);

    useEffect(() => {
        fetch("http://localhost:5108/api/course") // O "https://localhost:7140/api/course"
            .then(response => {
                if (!response.ok) {
                    throw new Error("Error fetching courses");
                }
                return response.json();
            })
            .then(data => setCourses(data))
            .catch(error => console.error("Fetch error:", error));
    }, []);

    return (
        <div>
            <h1>Lista de Cursos</h1>
            <ul>
                {courses.map((course) => (
                    <li key={course.id}>
                        {course.code} - {course.name} ({course.credits} créditos)
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default App;
