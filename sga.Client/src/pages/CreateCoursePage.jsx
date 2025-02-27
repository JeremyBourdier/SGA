import { useState } from "react";
import { useNavigate } from "react-router-dom";
import CourseForm from "../components/CourseForm";
import { createCourse } from "../api/CoursesApi";

function CreateCoursePage() {
    const navigate = useNavigate();
    const [successMsg, setSuccessMsg] = useState(null);
    const [errorMsg, setErrorMsg] = useState(null);

    const handleCreate = async (newCourse) => {
        const confirmar = window.confirm(
            `¿Seguro que deseas crear el curso con código "${newCourse.code}"?`
        );
        if (!confirmar) return;

        try {
            await createCourse(newCourse);
            setSuccessMsg("¡Curso creado exitosamente!");
            setErrorMsg(null);

            setTimeout(() => {
                navigate("/");
            }, 2000);

        } catch (error) {
            console.error("Error al crear curso:", error);

            // Manejo más detallado del error
            if (error.response) {
                // Si el backend devolvió un mensaje en error.response.data
                const serverMsg = error.response.data?.message; // Ajusta la propiedad según tu backend
                setErrorMsg(serverMsg || "Ocurrió un error al crear el curso.");
            } else {
                // error.request o error.message
                setErrorMsg("No se pudo crear el curso. Verifica tu conexión o intenta de nuevo.");
            }

            setSuccessMsg(null);
        }
    };

    return (
        <div className="container mt-4">
            <h1 className="mb-4">Crear Curso</h1>

            {/* Alertas de éxito o error */}
            {successMsg && <div className="alert alert-success">{successMsg}</div>}
            {errorMsg && <div className="alert alert-danger">{errorMsg}</div>}

            {/* Formulario para crear curso */}
            <CourseForm
                initialValues={{ code: "", name: "", credits: 0 }}
                onSubmit={handleCreate}
            />
        </div>
    );
}

export default CreateCoursePage;
