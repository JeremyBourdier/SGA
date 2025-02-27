import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getCourses, deleteCourse } from "../api/CoursesApi";

function CoursesPage() {
    const [courses, setCourses] = useState([]);
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    const fetchCourses = async () => {
        try {
            const data = await getCourses();
            setCourses(data);
        } catch (error) {
            console.error("Error al obtener los cursos:", error);
            setError("No se pudieron cargar los cursos");
        }
    };

    useEffect(() => {
        fetchCourses();
    }, []);

    const handleDelete = async (id) => {
        if (!window.confirm("¿Eliminar este curso?")) return;
        try {
            await deleteCourse(id);
            fetchCourses(); // recarga la lista
        } catch (error) {
            console.error("Error al eliminar curso", error);
        }
    };

    return (
        <div className="container mt-4">
            {/* Título */}
            <h1 className="mb-4">Lista de Cursos</h1>

            {/* Botón para crear nuevo curso */}
            <button
                className="btn btn-primary mb-3"
                onClick={() => navigate("/course/create")}
            >
                Nuevo Curso
            </button>

            {/* Mensaje de error */}
            {error && <p className="text-danger">{error}</p>}

            {courses.length > 0 ? (
                <ul className="list-group">
                    {courses.map(course => (
                        <li
                            key={course.id}
                            className="list-group-item d-flex justify-content-between align-items-center"
                        >
                            <div>
                                <strong>{course.code}</strong> - {course.name} ({course.credits} créditos)
                            </div>
                            <div>
                                <button
                                    className="btn btn-warning btn-sm me-2"
                                    onClick={() => navigate(`/course/${course.id}/edit`)}
                                >
                                    Editar
                                </button>
                                <button
                                    className="btn btn-danger btn-sm"
                                    onClick={() => handleDelete(course.id)}
                                >
                                    Eliminar
                                </button>
                            </div>
                        </li>
                    ))}
                </ul>
            ) : (
                <p>No hay cursos.</p>
            )}
        </div>
    );
}

export default CoursesPage;
