<template>
    <div>
        <h1 class="font-medium text-3xl text-slate-800 mb-16">Edit Employee</h1>

        <form class="mt-16" @submit.prevent="handleUpdate">
            <div class="grid gap-10 mb-6 md:grid-cols-2">
                <div>
                    <label for="first_name" class="block mb-2 text-sm font-medium text-gray-900">Name</label>
                    <input type="text" id="first_name" v-model="employee.name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 " placeholder="John" required>
                    <small class="text-xs hidden text-red-600">Name is required</small>
                </div>
                <div>
                    <label for="last_name" class="block mb-2 text-sm font-medium text-gray-900">Surname</label>
                    <input type="text" id="last_name" v-model="employee.surname" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 " placeholder="Doe" required>
                    <small class="text-xs hidden text-red-600">Manager is required</small>
                </div>
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">ID Number</label>
                    <input type="text" id="company" v-model="employee.idNumber" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 " placeholder="7458963652144" required>
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Job Title</label>
                    <input type="text" id="company" v-model="employee.jobTitle" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 " placeholder="Senior Software Engineer" required>
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Department Name</label>
                    <select v-model="employee.departmentId" id="countries" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Select department">
                        <option v-for="department in departments" :key="department.departmentId" :value="department.departmentId">{{department.departmentName}}</option>
                    </select>
                </div>  
            </div>
            <div class="flex justify-end items-center">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Update department</button>
                <NuxtLink to="/employees" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios'
import { ref } from 'vue';
import { useRoute } from 'vue-router';

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
    setup(){
        const id = ref(useRoute().params.id);
        const config = useRuntimeConfig()

        return {
            id,
            baseApi: config.public.apiBase
        };
    },
    created() {
        this.fetchEmployee()
        this.getDepartments();
    },
    methods: {
        async fetchEmployee() {
            try {
                var response = await axios.get(`${this.baseApi}/api/Employee/${this.id}`)
                //console.log(response.data)
                this.employee = response.data
            } catch (error) {
                console.log("Error getting employee: ", error.message)
            }
        },
        async getDepartments() {
            var response = await axios.get(`${this.baseApi}/api/Department/GetDepartments`);
            this.departments = response.data
        },
        async handleUpdate() {
            this.getSelectedDepartment(this.employee.departmentId)
            try {
                var response = await axios.put(`${this.baseApi}/api/Employee/${this.id}`, this.employee)
                console.log(response.data)
                this.$router.replace('/employees');
            } catch (error) {
                console.log("Error updating employee: ", error.message)
            }
        },
        async getSelectedDepartment(id) {
            var response = await axios.get(`${this.baseApi}/api/Department/GetDepartment/${id}`)
            this.employee.department = response.data;
            this.employee.departmentName = this.employee.department.departmentName
        },
    }
}
</script>