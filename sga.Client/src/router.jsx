import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import CoursesPage from "./pages/CoursesPage";
import CreateCoursePage from "./pages/CreateCoursePage";
import EditCoursePage from "./pages/EditCoursePage";

function AppRouter() {
    return (
        <Router>
            <Routes>
                {/* Lista de cursos en "/" */}
                <Route path="/" element={<CoursesPage />} />

                {/* Crear nuevo curso */}
                <Route path="/course/create" element={<CreateCoursePage />} />

                {/* Editar un curso existente */}
                <Route path="/course/:id/edit" element={<EditCoursePage />} />
            </Routes>
        </Router>
    );
}

export default AppRouter;
