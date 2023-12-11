<template>
    <div>
        
        <div class="flex justify-between items-center">
            <h1 class="font-medium text-3xl text-slate-800 mb-16">Employees</h1>
            <NuxtLink to="/employees/add" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Add Employee</NuxtLink>
        </div>

        <div class="relative overflow-x-auto">
            <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                    <tr>
                        <th scope="col" class="px-6 py-3">
                            Name
                        </th>
                        <th scope="col" class="px-6 py-3">
                            Surname
                        </th>
                        <th scope="col" class="px-6 py-3">
                            ID Number
                        </th>
                        <th scope="col" class="px-6 py-3">
                            Job Title
                        </th>
                        <th scope="col" class="px-6 py-3">
                            Department Name
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="odd:bg-white even:bg-gray-50 border-b" v-for="employee in employees" :key="employee.employeeId">
                        <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                            {{employee.name}}
                        </th>
                        <td class="px-6 py-4">
                            {{employee.surname}}
                        </td>
                        <td class="px-6 py-4">
                            {{employee.idNumber}}
                        </td>
                        <td class="px-6 py-4">
                            {{employee.jobTitle}}
                        </td>
                        <td class="px-6 py-4">
                            {{employee.department.departmentName}}
                        </td>
                        <td class="px-6 py-4 space-x-5">
                            <NuxtLink :to="`/update-employee/${employee.employeeId}`" class="font-medium text-blue-600 hover:underline">Edit</NuxtLink>
                            <NuxtLink :to="`/delete-employee/${employee.employeeId}`" class="font-medium text-red-600 hover:underline">Delete</NuxtLink>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default{
    data() {
        return {
            employees: []
        }
        
    },
    setup(){
        const config = useRuntimeConfig()
        return {
            baseApi: config.public.apiBase
        }
    },
    created(){
        this.getEmployees()
    },
    methods: {
        async getEmployees() {
            try{
                var response = await axios.get(`${this.baseApi}/api/Employee`);
                //console.log(response.data)
                this.employees = response.data
            } catch(error) {
                console.log("Error getting employees: ", error.message)
            }
        }
    }
}
</script>