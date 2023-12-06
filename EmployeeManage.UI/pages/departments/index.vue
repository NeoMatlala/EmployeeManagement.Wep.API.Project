<template>
    <div class="max-w-7xl mx-auto">
        <h1 class="font-medium text-6xl mb-16">Departments</h1>

        <div class="relative overflow-x-auto">
            <table class="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
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
                    <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700" v-for="department in departments" :key="department.departmentId">
                        <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
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
    created(){
        this.fetchDepartments();
    },
    methods:{
        async fetchDepartments(){
            try{
                var response = await axios.get('https://localhost:7244/api/Department/GetDepartments');
                this.departments = response.data
                console.log(response.data)
            } catch(error){
                console.log('Error fetching departments', error.message)
            }
        }
    }
} 
</script>