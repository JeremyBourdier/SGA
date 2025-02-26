import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import CoursesPage from "./pages/CoursesPage";

function AppRouter() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<CoursesPage />} />
            </Routes>
        </Router>
    );
}

export default AppRouter;
