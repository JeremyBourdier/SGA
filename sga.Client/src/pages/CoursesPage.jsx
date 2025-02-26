import { useEffect, useState } from "react";
import { getCourses } from "../api/coursesApi";

function CoursesPage() {
    const [courses, setCourses] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchCourses = async () => {
            try {
                const data = await getCourses();
                setCourses(data);
            } catch (error) {
                console.error("Error al obtener los cursos:", error);
                setError("Error al obtener los cursos");
            }
        };
        fetchCourses();
    }, []);

    return (
        <div>
            <h1>Lista de Cursos</h1>
            {error && <p style={{ color: "red" }}>{error}</p>}
            {courses.length > 0 ? (
                <ul>
                    {courses.map(course => (
                        <li key={course.id}>{course.name}</li>
                    ))}
                </ul>
            ) : (
                <p>No hay cursos disponibles.</p>
            )}
        </div>
    );
}

export default CoursesPage;
