import apiClient from "./apiClient";

export const getCourses = async () => {
    try {
        const response = await apiClient.get("/Course");
        return response.data;
    } catch (error) {
        console.error("Error fetching courses", error);
        throw error;
    }
};

export const getCourseById = async (id) => {
    try {
        const response = await apiClient.get(`/Course/${id}`);
        return response.data;
    } catch (error) {
        console.error("Error fetching course by ID", error);
        throw error;
    }
};

export const createCourse = async (course) => {
    try {
        const response = await apiClient.post("/Course", course);
        return response.data;
    } catch (error) {
        console.error("Error creating course", error);
        throw error;
    }
};

export const updateCourse = async (id, course) => {
    try {
        await apiClient.put(`/Course/${id}`, course);
    } catch (error) {
        console.error("Error updating course", error);
        throw error;
    }
};

export const deleteCourse = async (id) => {
    try {
        await apiClient.delete(`/Course/${id}`);
    } catch (error) {
        console.error("Error deleting course", error);
        throw error;
    }
};
