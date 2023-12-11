<template>
    <div>
        <div class="flex justify-between items-center mb-12">
            <h1 class="font-medium text-3xl text-slate-800">Departments</h1>
            <NuxtLink to="/departments/add" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Add department</NuxtLink>
        </div>
        

        <div class="relative overflow-x-auto">
            <table class="w-full text-sm text-left rtl:text-right text-gray-500">
                <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                    <tr>
                        <th scope="col" class="px-6 py-3">
                            Department name
                        </th>
                        <th scope="col" class="px-6 py-3">
                            Manager
                        </th>
                        <th scope="col" class="px-6 py-3">
                            Members
                        </th>
                        <th scope="col" class="px-6 py-3">
                            Action
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="odd:bg-white even:bg-gray-50 border-b" v-for="department in departments" :key="department.departmentId">
                        <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                            {{ department.departmentName }}
                        </th>
                        <td class="px-6 py-4">
                            {{ department.manager }}
                        </td>
                        <td class="px-6 py-4">
                            {{ department.members }}
                        </td>
                        <td class="px-6 py-4 space-x-5">
                            <NuxtLink :to="`/update-department/${department.departmentId}`" class="font-medium text-blue-600 hover:underline">Edit</NuxtLink>
                            <NuxtLink :to="`/delete-department/${department.departmentId}`" class="font-medium text-red-600 hover:underline">Delete</NuxtLink>
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
    data(){
        return{
            departments: []
        }
    },
    setup(){
        const config = useRuntimeConfig()
        return {
            baseApi: config.public.apiBase
        }
    },
    created(){
        this.fetchDepartments();
    },
    methods:{
        async fetchDepartments(){
            try{
                var response = await axios.get(`${this.baseApi}/api/Department/GetDepartments`);
                this.departments = response.data
                console.log(response.data)
            } catch(error){
                console.log('Error fetching departments', error.message)
            }
        }
    }
} 
</script>