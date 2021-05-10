extern "C" void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_SharedInternals();
	RegisterModule_SharedInternals();

	void RegisterModule_Core();
	RegisterModule_Core();

	void RegisterModule_Animation();
	RegisterModule_Animation();

<<<<<<< Updated upstream
=======
	void RegisterModule_AR();
	RegisterModule_AR();

>>>>>>> Stashed changes
	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_ImageConversion();
	RegisterModule_ImageConversion();

	void RegisterModule_GameCenter();
	RegisterModule_GameCenter();

<<<<<<< Updated upstream
	void RegisterModule_InputLegacy();
	RegisterModule_InputLegacy();

	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

	void RegisterModule_JSONSerialize();
	RegisterModule_JSONSerialize();

=======
	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

	void RegisterModule_Input();
	RegisterModule_Input();

	void RegisterModule_InputLegacy();
	RegisterModule_InputLegacy();

	void RegisterModule_JSONSerialize();
	RegisterModule_JSONSerialize();

	void RegisterModule_ParticleSystem();
	RegisterModule_ParticleSystem();

>>>>>>> Stashed changes
	void RegisterModule_Physics();
	RegisterModule_Physics();

	void RegisterModule_RuntimeInitializeOnLoadManagerInitializer();
	RegisterModule_RuntimeInitializeOnLoadManagerInitializer();

<<<<<<< Updated upstream
	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

=======
	void RegisterModule_Subsystems();
	RegisterModule_Subsystems();

	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

	void RegisterModule_TextCore();
	RegisterModule_TextCore();

>>>>>>> Stashed changes
	void RegisterModule_TLS();
	RegisterModule_TLS();

	void RegisterModule_UI();
	RegisterModule_UI();

	void RegisterModule_UnityWebRequest();
	RegisterModule_UnityWebRequest();

<<<<<<< Updated upstream
=======
	void RegisterModule_XR();
	RegisterModule_XR();

>>>>>>> Stashed changes
}

template <typename T> void RegisterUnityClass(const char*);
template <typename T> void RegisterStrippedType(int, const char*, const char*);

void InvokeRegisterStaticallyLinkedModuleClasses()
{
	// Do nothing (we're in stripping mode)
}

namespace ObjectProduceTestTypes { class Derived; } 
namespace ObjectProduceTestTypes { class SubDerived; } 
class EditorExtension; template <> void RegisterUnityClass<EditorExtension>(const char*);
namespace Unity { class Component; } template <> void RegisterUnityClass<Unity::Component>(const char*);
class Behaviour; template <> void RegisterUnityClass<Behaviour>(const char*);
class Animation; 
class Animator; template <> void RegisterUnityClass<Animator>(const char*);
namespace Unity { class ArticulationBody; } 
class AudioBehaviour; template <> void RegisterUnityClass<AudioBehaviour>(const char*);
class AudioListener; template <> void RegisterUnityClass<AudioListener>(const char*);
class AudioSource; 
class AudioFilter; 
class AudioChorusFilter; 
class AudioDistortionFilter; 
class AudioEchoFilter; 
class AudioHighPassFilter; 
class AudioLowPassFilter; 
class AudioReverbFilter; 
class AudioReverbZone; 
class Camera; template <> void RegisterUnityClass<Camera>(const char*);
namespace UI { class Canvas; } template <> void RegisterUnityClass<UI::Canvas>(const char*);
namespace UI { class CanvasGroup; } template <> void RegisterUnityClass<UI::CanvasGroup>(const char*);
namespace Unity { class Cloth; } 
class Collider2D; 
class BoxCollider2D; 
class CapsuleCollider2D; 
class CircleCollider2D; 
class CompositeCollider2D; 
class EdgeCollider2D; 
class PolygonCollider2D; 
class TilemapCollider2D; 
class ConstantForce; 
class Effector2D; 
class AreaEffector2D; 
class BuoyancyEffector2D; 
class PlatformEffector2D; 
class PointEffector2D; 
class SurfaceEffector2D; 
class FlareLayer; 
class GridLayout; 
class Grid; 
class Tilemap; 
class Halo; 
class HaloLayer; 
class IConstraint; 
class AimConstraint; 
class LookAtConstraint; 
class ParentConstraint; 
class PositionConstraint; 
class RotationConstraint; 
class ScaleConstraint; 
class Joint2D; 
class AnchoredJoint2D; 
class DistanceJoint2D; 
class FixedJoint2D; 
class FrictionJoint2D; 
class HingeJoint2D; 
class SliderJoint2D; 
class SpringJoint2D; 
class WheelJoint2D; 
class RelativeJoint2D; 
class TargetJoint2D; 
class LensFlare; 
class Light; template <> void RegisterUnityClass<Light>(const char*);
class LightProbeGroup; 
class LightProbeProxyVolume; 
class MonoBehaviour; template <> void RegisterUnityClass<MonoBehaviour>(const char*);
class NavMeshAgent; 
class NavMeshObstacle; 
class OffMeshLink; 
class ParticleSystemForceField; 
class PhysicsUpdateBehaviour2D; 
class ConstantForce2D; 
class PlayableDirector; 
class Projector; 
class ReflectionProbe; template <> void RegisterUnityClass<ReflectionProbe>(const char*);
class Skybox; 
class SortingGroup; 
class StreamingController; 
class Terrain; 
class VideoPlayer; 
class VisualEffect; 
class WindZone; 
namespace UI { class CanvasRenderer; } template <> void RegisterUnityClass<UI::CanvasRenderer>(const char*);
class Collider; template <> void RegisterUnityClass<Collider>(const char*);
class BoxCollider; template <> void RegisterUnityClass<BoxCollider>(const char*);
class CapsuleCollider; 
class CharacterController; 
class MeshCollider; template <> void RegisterUnityClass<MeshCollider>(const char*);
class SphereCollider; 
class TerrainCollider; 
class WheelCollider; 
class FakeComponent; 
namespace Unity { class Joint; } 
namespace Unity { class CharacterJoint; } 
namespace Unity { class ConfigurableJoint; } 
namespace Unity { class FixedJoint; } 
namespace Unity { class HingeJoint; } 
namespace Unity { class SpringJoint; } 
class LODGroup; 
class MeshFilter; template <> void RegisterUnityClass<MeshFilter>(const char*);
class OcclusionArea; 
class OcclusionPortal; 
<<<<<<< Updated upstream
class ParticleSystem; 
class Renderer; template <> void RegisterUnityClass<Renderer>(const char*);
class BillboardRenderer; 
class LineRenderer; 
class RendererFake; 
class MeshRenderer; template <> void RegisterUnityClass<MeshRenderer>(const char*);
class ParticleSystemRenderer; 
class SkinnedMeshRenderer; 
class SpriteMask; 
class SpriteRenderer; 
=======
class ParticleSystem; template <> void RegisterUnityClass<ParticleSystem>(const char*);
class Renderer; template <> void RegisterUnityClass<Renderer>(const char*);
class BillboardRenderer; 
class LineRenderer; template <> void RegisterUnityClass<LineRenderer>(const char*);
class RendererFake; 
class MeshRenderer; template <> void RegisterUnityClass<MeshRenderer>(const char*);
class ParticleSystemRenderer; template <> void RegisterUnityClass<ParticleSystemRenderer>(const char*);
class SkinnedMeshRenderer; template <> void RegisterUnityClass<SkinnedMeshRenderer>(const char*);
class SpriteMask; 
class SpriteRenderer; template <> void RegisterUnityClass<SpriteRenderer>(const char*);
>>>>>>> Stashed changes
class SpriteShapeRenderer; 
class TilemapRenderer; 
class TrailRenderer; 
class VFXRenderer; 
<<<<<<< Updated upstream
class Rigidbody; 
class Rigidbody2D; 
namespace TextRenderingPrivate { class TextMesh; } 
=======
class Rigidbody; template <> void RegisterUnityClass<Rigidbody>(const char*);
class Rigidbody2D; 
namespace TextRenderingPrivate { class TextMesh; } template <> void RegisterUnityClass<TextRenderingPrivate::TextMesh>(const char*);
>>>>>>> Stashed changes
class Transform; template <> void RegisterUnityClass<Transform>(const char*);
namespace UI { class RectTransform; } template <> void RegisterUnityClass<UI::RectTransform>(const char*);
class Tree; 
class GameObject; template <> void RegisterUnityClass<GameObject>(const char*);
class NamedObject; template <> void RegisterUnityClass<NamedObject>(const char*);
class AssetBundle; 
class AssetBundleManifest; 
class AudioMixer; 
class AudioMixerController; 
class AudioMixerGroup; 
class AudioMixerGroupController; 
class AudioMixerSnapshot; 
class AudioMixerSnapshotController; 
class Avatar; 
class AvatarMask; 
class BillboardAsset; 
class ComputeShader; template <> void RegisterUnityClass<ComputeShader>(const char*);
class Flare; 
namespace TextRendering { class Font; } template <> void RegisterUnityClass<TextRendering::Font>(const char*);
class LightProbes; 
class LightingSettings; template <> void RegisterUnityClass<LightingSettings>(const char*);
class LocalizationAsset; 
class Material; template <> void RegisterUnityClass<Material>(const char*);
class ProceduralMaterial; 
class Mesh; template <> void RegisterUnityClass<Mesh>(const char*);
class Motion; 
class AnimationClip; 
class NavMeshData; 
class OcclusionCullingData; 
class PhysicMaterial; 
class PhysicsMaterial2D; 
class PreloadData; template <> void RegisterUnityClass<PreloadData>(const char*);
class RayTracingShader; 
class RuntimeAnimatorController; template <> void RegisterUnityClass<RuntimeAnimatorController>(const char*);
class AnimatorController; template <> void RegisterUnityClass<AnimatorController>(const char*);
class AnimatorOverrideController; template <> void RegisterUnityClass<AnimatorOverrideController>(const char*);
class SampleClip; template <> void RegisterUnityClass<SampleClip>(const char*);
class AudioClip; template <> void RegisterUnityClass<AudioClip>(const char*);
class Shader; template <> void RegisterUnityClass<Shader>(const char*);
class ShaderVariantCollection; 
class SpeedTreeWindAsset; 
class Sprite; template <> void RegisterUnityClass<Sprite>(const char*);
class SpriteAtlas; template <> void RegisterUnityClass<SpriteAtlas>(const char*);
class SubstanceArchive; 
class TerrainData; 
class TerrainLayer; 
class TextAsset; template <> void RegisterUnityClass<TextAsset>(const char*);
class MonoScript; template <> void RegisterUnityClass<MonoScript>(const char*);
class Texture; template <> void RegisterUnityClass<Texture>(const char*);
class BaseVideoTexture; template <> void RegisterUnityClass<BaseVideoTexture>(const char*);
class WebCamTexture; template <> void RegisterUnityClass<WebCamTexture>(const char*);
class CubemapArray; template <> void RegisterUnityClass<CubemapArray>(const char*);
class LowerResBlitTexture; template <> void RegisterUnityClass<LowerResBlitTexture>(const char*);
class MovieTexture; 
class ProceduralTexture; 
class RenderTexture; template <> void RegisterUnityClass<RenderTexture>(const char*);
class CustomRenderTexture; 
class SparseTexture; 
class Texture2D; template <> void RegisterUnityClass<Texture2D>(const char*);
class Cubemap; template <> void RegisterUnityClass<Cubemap>(const char*);
class Texture2DArray; template <> void RegisterUnityClass<Texture2DArray>(const char*);
class Texture3D; template <> void RegisterUnityClass<Texture3D>(const char*);
class VideoClip; 
class VisualEffectObject; 
class VisualEffectAsset; 
class VisualEffectSubgraph; 
class EmptyObject; 
class GameManager; template <> void RegisterUnityClass<GameManager>(const char*);
class GlobalGameManager; template <> void RegisterUnityClass<GlobalGameManager>(const char*);
class AudioManager; template <> void RegisterUnityClass<AudioManager>(const char*);
class BuildSettings; template <> void RegisterUnityClass<BuildSettings>(const char*);
class DelayedCallManager; template <> void RegisterUnityClass<DelayedCallManager>(const char*);
class GraphicsSettings; template <> void RegisterUnityClass<GraphicsSettings>(const char*);
class InputManager; template <> void RegisterUnityClass<InputManager>(const char*);
class MonoManager; template <> void RegisterUnityClass<MonoManager>(const char*);
class NavMeshProjectSettings; 
class Physics2DSettings; 
class PhysicsManager; template <> void RegisterUnityClass<PhysicsManager>(const char*);
class PlayerSettings; template <> void RegisterUnityClass<PlayerSettings>(const char*);
class QualitySettings; template <> void RegisterUnityClass<QualitySettings>(const char*);
class ResourceManager; template <> void RegisterUnityClass<ResourceManager>(const char*);
class RuntimeInitializeOnLoadManager; template <> void RegisterUnityClass<RuntimeInitializeOnLoadManager>(const char*);
class ScriptMapper; template <> void RegisterUnityClass<ScriptMapper>(const char*);
class StreamingManager; 
class TagManager; template <> void RegisterUnityClass<TagManager>(const char*);
class TimeManager; template <> void RegisterUnityClass<TimeManager>(const char*);
class UnityConnectSettings; 
class VFXManager; 
class LevelGameManager; template <> void RegisterUnityClass<LevelGameManager>(const char*);
class LightmapSettings; template <> void RegisterUnityClass<LightmapSettings>(const char*);
class NavMeshSettings; 
class OcclusionCullingSettings; 
class RenderSettings; template <> void RegisterUnityClass<RenderSettings>(const char*);
class NativeObjectType; 
class PropertyModificationsTargetTestObject; 
class SerializableManagedHost; 
class SerializableManagedRefTestClass; 
namespace ObjectProduceTestTypes { class SiblingDerived; } 
class TestObjectVectorPairStringBool; 
class TestObjectWithSerializedAnimationCurve; 
class TestObjectWithSerializedArray; 
class TestObjectWithSerializedMapStringBool; 
class TestObjectWithSerializedMapStringNonAlignedStruct; 
class TestObjectWithSpecialLayoutOne; 
class TestObjectWithSpecialLayoutTwo; 

void RegisterAllClasses()
{
void RegisterBuiltinTypes();
RegisterBuiltinTypes();
<<<<<<< Updated upstream
	//Total: 69 non stripped classes
=======
	//Total: 76 non stripped classes
>>>>>>> Stashed changes
	//0. Animator
	RegisterUnityClass<Animator>("Animation");
	//1. AnimatorController
	RegisterUnityClass<AnimatorController>("Animation");
	//2. AnimatorOverrideController
	RegisterUnityClass<AnimatorOverrideController>("Animation");
	//3. RuntimeAnimatorController
	RegisterUnityClass<RuntimeAnimatorController>("Animation");
	//4. AudioBehaviour
	RegisterUnityClass<AudioBehaviour>("Audio");
	//5. AudioClip
	RegisterUnityClass<AudioClip>("Audio");
	//6. AudioListener
	RegisterUnityClass<AudioListener>("Audio");
	//7. AudioManager
	RegisterUnityClass<AudioManager>("Audio");
	//8. BaseVideoTexture
	RegisterUnityClass<BaseVideoTexture>("Audio");
	//9. SampleClip
	RegisterUnityClass<SampleClip>("Audio");
	//10. WebCamTexture
	RegisterUnityClass<WebCamTexture>("Audio");
	//11. Behaviour
	RegisterUnityClass<Behaviour>("Core");
	//12. BuildSettings
	RegisterUnityClass<BuildSettings>("Core");
	//13. Camera
	RegisterUnityClass<Camera>("Core");
	//14. Unity::Component
	RegisterUnityClass<Unity::Component>("Core");
	//15. ComputeShader
	RegisterUnityClass<ComputeShader>("Core");
	//16. Cubemap
	RegisterUnityClass<Cubemap>("Core");
	//17. CubemapArray
	RegisterUnityClass<CubemapArray>("Core");
	//18. DelayedCallManager
	RegisterUnityClass<DelayedCallManager>("Core");
	//19. EditorExtension
	RegisterUnityClass<EditorExtension>("Core");
	//20. GameManager
	RegisterUnityClass<GameManager>("Core");
	//21. GameObject
	RegisterUnityClass<GameObject>("Core");
	//22. GlobalGameManager
	RegisterUnityClass<GlobalGameManager>("Core");
	//23. GraphicsSettings
	RegisterUnityClass<GraphicsSettings>("Core");
	//24. InputManager
	RegisterUnityClass<InputManager>("Core");
	//25. LevelGameManager
	RegisterUnityClass<LevelGameManager>("Core");
	//26. Light
	RegisterUnityClass<Light>("Core");
	//27. LightingSettings
	RegisterUnityClass<LightingSettings>("Core");
	//28. LightmapSettings
	RegisterUnityClass<LightmapSettings>("Core");
<<<<<<< Updated upstream
	//29. LowerResBlitTexture
	RegisterUnityClass<LowerResBlitTexture>("Core");
	//30. Material
	RegisterUnityClass<Material>("Core");
	//31. Mesh
	RegisterUnityClass<Mesh>("Core");
	//32. MeshFilter
	RegisterUnityClass<MeshFilter>("Core");
	//33. MeshRenderer
	RegisterUnityClass<MeshRenderer>("Core");
	//34. MonoBehaviour
	RegisterUnityClass<MonoBehaviour>("Core");
	//35. MonoManager
	RegisterUnityClass<MonoManager>("Core");
	//36. MonoScript
	RegisterUnityClass<MonoScript>("Core");
	//37. NamedObject
	RegisterUnityClass<NamedObject>("Core");
	//38. Object
	//Skipping Object
	//39. PlayerSettings
	RegisterUnityClass<PlayerSettings>("Core");
	//40. PreloadData
	RegisterUnityClass<PreloadData>("Core");
	//41. QualitySettings
	RegisterUnityClass<QualitySettings>("Core");
	//42. UI::RectTransform
	RegisterUnityClass<UI::RectTransform>("Core");
	//43. ReflectionProbe
	RegisterUnityClass<ReflectionProbe>("Core");
	//44. Renderer
	RegisterUnityClass<Renderer>("Core");
	//45. RenderSettings
	RegisterUnityClass<RenderSettings>("Core");
	//46. RenderTexture
	RegisterUnityClass<RenderTexture>("Core");
	//47. ResourceManager
	RegisterUnityClass<ResourceManager>("Core");
	//48. RuntimeInitializeOnLoadManager
	RegisterUnityClass<RuntimeInitializeOnLoadManager>("Core");
	//49. ScriptMapper
	RegisterUnityClass<ScriptMapper>("Core");
	//50. Shader
	RegisterUnityClass<Shader>("Core");
	//51. Sprite
	RegisterUnityClass<Sprite>("Core");
	//52. SpriteAtlas
	RegisterUnityClass<SpriteAtlas>("Core");
	//53. TagManager
	RegisterUnityClass<TagManager>("Core");
	//54. TextAsset
	RegisterUnityClass<TextAsset>("Core");
	//55. Texture
	RegisterUnityClass<Texture>("Core");
	//56. Texture2D
	RegisterUnityClass<Texture2D>("Core");
	//57. Texture2DArray
	RegisterUnityClass<Texture2DArray>("Core");
	//58. Texture3D
	RegisterUnityClass<Texture3D>("Core");
	//59. TimeManager
	RegisterUnityClass<TimeManager>("Core");
	//60. Transform
	RegisterUnityClass<Transform>("Core");
	//61. BoxCollider
	RegisterUnityClass<BoxCollider>("Physics");
	//62. Collider
	RegisterUnityClass<Collider>("Physics");
	//63. MeshCollider
	RegisterUnityClass<MeshCollider>("Physics");
	//64. PhysicsManager
	RegisterUnityClass<PhysicsManager>("Physics");
	//65. TextRendering::Font
	RegisterUnityClass<TextRendering::Font>("TextRendering");
	//66. UI::Canvas
	RegisterUnityClass<UI::Canvas>("UI");
	//67. UI::CanvasGroup
	RegisterUnityClass<UI::CanvasGroup>("UI");
	//68. UI::CanvasRenderer
=======
	//29. LineRenderer
	RegisterUnityClass<LineRenderer>("Core");
	//30. LowerResBlitTexture
	RegisterUnityClass<LowerResBlitTexture>("Core");
	//31. Material
	RegisterUnityClass<Material>("Core");
	//32. Mesh
	RegisterUnityClass<Mesh>("Core");
	//33. MeshFilter
	RegisterUnityClass<MeshFilter>("Core");
	//34. MeshRenderer
	RegisterUnityClass<MeshRenderer>("Core");
	//35. MonoBehaviour
	RegisterUnityClass<MonoBehaviour>("Core");
	//36. MonoManager
	RegisterUnityClass<MonoManager>("Core");
	//37. MonoScript
	RegisterUnityClass<MonoScript>("Core");
	//38. NamedObject
	RegisterUnityClass<NamedObject>("Core");
	//39. Object
	//Skipping Object
	//40. PlayerSettings
	RegisterUnityClass<PlayerSettings>("Core");
	//41. PreloadData
	RegisterUnityClass<PreloadData>("Core");
	//42. QualitySettings
	RegisterUnityClass<QualitySettings>("Core");
	//43. UI::RectTransform
	RegisterUnityClass<UI::RectTransform>("Core");
	//44. ReflectionProbe
	RegisterUnityClass<ReflectionProbe>("Core");
	//45. Renderer
	RegisterUnityClass<Renderer>("Core");
	//46. RenderSettings
	RegisterUnityClass<RenderSettings>("Core");
	//47. RenderTexture
	RegisterUnityClass<RenderTexture>("Core");
	//48. ResourceManager
	RegisterUnityClass<ResourceManager>("Core");
	//49. RuntimeInitializeOnLoadManager
	RegisterUnityClass<RuntimeInitializeOnLoadManager>("Core");
	//50. ScriptMapper
	RegisterUnityClass<ScriptMapper>("Core");
	//51. Shader
	RegisterUnityClass<Shader>("Core");
	//52. SkinnedMeshRenderer
	RegisterUnityClass<SkinnedMeshRenderer>("Core");
	//53. Sprite
	RegisterUnityClass<Sprite>("Core");
	//54. SpriteAtlas
	RegisterUnityClass<SpriteAtlas>("Core");
	//55. SpriteRenderer
	RegisterUnityClass<SpriteRenderer>("Core");
	//56. TagManager
	RegisterUnityClass<TagManager>("Core");
	//57. TextAsset
	RegisterUnityClass<TextAsset>("Core");
	//58. Texture
	RegisterUnityClass<Texture>("Core");
	//59. Texture2D
	RegisterUnityClass<Texture2D>("Core");
	//60. Texture2DArray
	RegisterUnityClass<Texture2DArray>("Core");
	//61. Texture3D
	RegisterUnityClass<Texture3D>("Core");
	//62. TimeManager
	RegisterUnityClass<TimeManager>("Core");
	//63. Transform
	RegisterUnityClass<Transform>("Core");
	//64. ParticleSystem
	RegisterUnityClass<ParticleSystem>("ParticleSystem");
	//65. ParticleSystemRenderer
	RegisterUnityClass<ParticleSystemRenderer>("ParticleSystem");
	//66. BoxCollider
	RegisterUnityClass<BoxCollider>("Physics");
	//67. Collider
	RegisterUnityClass<Collider>("Physics");
	//68. MeshCollider
	RegisterUnityClass<MeshCollider>("Physics");
	//69. PhysicsManager
	RegisterUnityClass<PhysicsManager>("Physics");
	//70. Rigidbody
	RegisterUnityClass<Rigidbody>("Physics");
	//71. TextRendering::Font
	RegisterUnityClass<TextRendering::Font>("TextRendering");
	//72. TextRenderingPrivate::TextMesh
	RegisterUnityClass<TextRenderingPrivate::TextMesh>("TextRendering");
	//73. UI::Canvas
	RegisterUnityClass<UI::Canvas>("UI");
	//74. UI::CanvasGroup
	RegisterUnityClass<UI::CanvasGroup>("UI");
	//75. UI::CanvasRenderer
>>>>>>> Stashed changes
	RegisterUnityClass<UI::CanvasRenderer>("UI");

}
