import axios from "axios";

const AxiosInstance = axios.create({
    baseURL: 'http://localhost:27140'
});

const AppService = {

    getSearchResults(searchText) {
        return AxiosInstance.get(`/api/pokemon/${searchText}`).then(resp => resp.data);
    }
};


export default AppService;