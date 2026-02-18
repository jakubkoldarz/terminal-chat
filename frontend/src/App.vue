<script setup lang="ts">
  import { ref } from 'vue';
  import TerminalForm from './components/TerminalForm.vue';
  import Typewriter from './components/Typewriter.vue';
  import type { TerminalField } from './types/TerminalField';

  const isLoading = ref(false);
  const chosenOption = ref<'login' | 'register' | null>(null);

  const choiceFields: TerminalField[] = [
    {
      name: 'choice',
      label: 'Do you want to login or register?',
      validationPattern: /^(login|register)$/,
      errorMessage: 'Please enter a valid option (login, register).',
    },
  ];

  const authFields: TerminalField[] = [
    {
      name: 'login',
      validationPattern: /^[a-zA-Z0-9]{6,}$/,
      errorMessage:
        'Login must be at least 6 characters long and contain only letters and numbers.',
    },
    {
      name: 'password',
      validationPattern: /^[a-zA-Z0-9]{8,}$/,
      errorMessage: 'Password must be at least 8 characters long',
      isPassword: true,
    },
  ];

  function handleLogin(data: Record<string, string>) {
    // const password = data.password;
    // const login = data.login;
    isLoading.value = true;
  }

  function handleRegister(data: Record<string, string>) {
    // const password = data.password;
    // const login = data.login;
    isLoading.value = true;
  }

  function handleChoiceSubmit(data: Record<string, string>) {
    const choice = data.choice;
    if (!choice) return;

    if (choice == 'login' || choice == 'register') {
      chosenOption.value = choice;
    }
  }
</script>

<template>
  <div
    class="bg-terminal-dark min-h-screen w-full p-12 text-terminal-green font-terminal text-2xl"
  >
    <TerminalForm
      v-if="!chosenOption"
      :fields="choiceFields"
      @submit="handleChoiceSubmit"
    ></TerminalForm>
    <TerminalForm
      v-if="chosenOption == 'login'"
      :fields="authFields"
      @submit="handleLogin"
    ></TerminalForm>
    <TerminalForm
      v-if="chosenOption == 'register'"
      :fields="authFields"
      @submit="handleRegister"
    ></TerminalForm>
    <Typewriter v-if="isLoading" text="Loading..."> </Typewriter>
  </div>
</template>
