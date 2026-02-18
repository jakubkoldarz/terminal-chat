<script setup lang="ts">
  import { onMounted, ref } from 'vue';

  const props = withDefaults(
    defineProps<{
      text: string;
      typingSpeed?: number;
      showTyping?: boolean;
    }>(),
    {
      showTyping: false,
      typingSpeed: 10,
    }
  );

  const displayedText = ref('');
  const isTyping = ref(false);
  function typeText() {
    displayedText.value = '';
    isTyping.value = true;
    let i = 0;
    const speed = props.typingSpeed;

    const typingInterval = setInterval(() => {
      displayedText.value += props.text.charAt(i);
      i++;

      if (i >= props.text.length) {
        clearInterval(typingInterval);
        isTyping.value = false;
      }
    }, speed);
  }

  onMounted(() => {
    typeText();
  });
</script>

<template>
  <span class="whitespace-nowrap">
    {{ displayedText }}
  </span>
</template>
