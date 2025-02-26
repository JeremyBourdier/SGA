import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import CourseForm from "../components/CourseForm";
import { getCourseById, updateCourse } from "../api/CoursesApi";

function EditCoursePage() {
    const { id } = useParams();
    const navigate = useNavigate();
    const [course, setCourse] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchCourse = async () => {
            try {
                const data = await getCourseById(id);
                setCourse(data);
            } catch (error) {
                console.error("Error al obtener curso", error);
            } finally {
                setLoading(false);
            }
        };
        fetchCourse();
    }, [id]);

    const handleUpdate = async (updated) => {
        try {
            await updateCourse(id, updated);
            navigate("/");
        } catch (error) {
            console.error("Error al actualizar curso", error);
        }
    };

    if (loading) return <p>Cargando...</p>;
    if (!course) return <p>No se encontró el curso.</p>;

    return (
        <div>
            <h1>Editar Curso</h1>
            <CourseForm
                initialValues={course}
                onSubmit={handleUpdate}
            />
        </div>
    );
}

export default EditCoursePage;
