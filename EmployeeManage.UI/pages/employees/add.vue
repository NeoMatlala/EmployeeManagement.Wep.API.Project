<template>
    <div class="max-w-7xl mx-auto">
        <h1 class="font-medium text-4xl">Create Employee</h1>

        <form class="mt-16" @submit.prevent="CreateEmployee">
            <div class="grid gap-10 mb-6 md:grid-cols-2">
                <div>
                    <label for="first_name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Name</label>
                    <input type="text" id="first_name" v-model="employee.name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="John" required>
                    <small class="text-xs hidden text-red-600">Name is required</small>
                </div>
                <div>
                    <label for="last_name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Surname</label>
                    <input type="text" id="last_name" v-model="employee.surname" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Doe" required>
                    <small class="text-xs hidden text-red-600">Manager is required</small>
                </div>
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">ID Number</label>
                    <input type="text" id="company" v-model="employee.idNumber" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="7458963652144" required>
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Job Title</label>
                    <input type="text" id="company" v-model="employee.jobTitle" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Senior Software Engineer" required>
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Department Name</label>
                    <select v-model="employee.departmentId" id="countries" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Select department">
                        <option v-for="department in departments" :key="department.departmentId" :value="department.departmentId">{{department.departmentName}}</option>
                    </select>
                </div>  
            </div>
            <div class="flex justify-end items-center">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Create Employee</button>
                <NuxtLink to="/employees" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios';

export default{
    data() {
        return {
            employee: {
                name: '',
                surname: '',
                idNumber: '',
                jobTitle: '',
                departmentId: '',
                departmentName: '',
                department: {
                    departmentId: 0, 
                    departmentName: '',
                    manager: '',
                    members: 0  
                }
            },
            departments: []
        }
    },
    created () {
        this.getDepartments();
    },
    methods: {
        async getDepartments() {
            var response = await axios.get("https://localhost:7244/api/Department/GetDepartments");
            this.departments = response.data
        },
        async CreateEmployee() {
            this.getSelectedDepartment(this.employee.departmentId)

            try {
                var response = await axios.post("https://localhost:7244/api/Employee", this.employee)
                
                console.log(response.data)
                this.$router.replace('/employees');
            } catch (error) {
                console.log("Error creating employee: ", error.message);
                if (error.response) {
                    // The request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    console.log("Server response data:", error.response.data);
                    console.log("Status code:", error.response.status);
                } else if (error.request) {
                    // The request was made but no response was received
                    console.log("No response received from the server");
                } else {
                    // Something happened in setting up the request that triggered an Error
                    console.log("Error:", error.message);
                }
            }
        },
        async getSelectedDepartment(id) {
            var response = await axios.get(`https://localhost:7244/api/Department/GetDepartment/${id}`)
            this.employee.department = response.data;
            this.employee.departmentName = this.employee.department.departmentName
        }
    }
}
</script>